﻿
# Mail System (i.e. MailChimp, SendGrid)

## Approach
System runs in a Kubernetes cluster behind a cloud-based load balancer.

Items external to the cluster are all databases, message bus (i.e. SNS/SQS, Az Svc Bus), and blob storage (S3, etc);
***
## Components

### API
Assumptions:
- Template for which this incoming request exists
- Authentication and authorization (likely JWT) beyond scope

Example usages:

Create future:
POST to: /api/campaigns

Example body:
```
{
  "CampaignId": <string/Guid>,
  "TemplateId": <string/Guid>,
  "FrequencyType": <int>,
  "SendAtUtc": <string/dateTime>,
  ...
}
```
On-Demand:

POST to: /api/templates

Example body:
```
{
  "TemplateId": <string/Guid>,
  ...
}
```

Other endpoints, such as a link to unsubscribe from a mailing campaign are also beyond the scope of this first design, but must be handled.
***
### Schedulers
Schedulers take incoming API requests from the queue and determine whether they need to be processed immediately, on a delay, or as a cron job.
***
### Engines
Engines are responsible for generating outbound content. Templates are pulled from a NoSql database where they are stored in JSON format.  Each engine knows how to process a template and create the finished content.

Upon generation, the completed content is uploaded to external blob storage.  Retention policy for generated content is likely beyond the scope of this initial design, but can envision a configurable policy of a reasonable value (eg. 30 days) for any issues and posterity.  Archiving any examples of content would be subject of a future discussion.

After content is uploaded to blob storage, an event is raised and sent to the Outbound Queue.

Data usage of blob storage would be minimized due to utilization of compression and CDNs for static content.
***
### Processors
Processors monitor the Outbound Queue and are responsible for transmitting the generated content via one or more external providers (eg. SMTP, SNS/MMS)
***
### Considerations
- How many documents are being generated daily?
- What is the average size?
- How does that translate into cloud storage costs?
- How will we process retries from the error queue?
- Need to generate an integration event once a document has been transmitted to external provider(s)
- Need to aggregate campaign information with number successful, returned, unsubcribed, etc
- Are we a startup?  If so, perhaps we should start with fewer microservices?  Modular monolith then detect where the bottlenecks are and break them out?
***
```mermaid
flowchart LR
subgraph Clients
    M[Mobile]
    PC[PC]
    H[Headless]
end
subgraph LoadBalancer
end
subgraph API
    API0[API0]
    API1[API1]
    APIN["API(n)"]
end
LoadBalancer --> API0
LoadBalancer --> API1
LoadBalancer --> APIN
DBSQL@{ shape: lin-cyl, label: "Client Requests (SQL)" }
Q0@{ shape: bow-rect, label: "Requests Queue" }
API0 -->|Request Data|DBSQL
API0 -->|RequestCreated|Q0
API1 -->|Request Data|DBSQL
API1 -->|RequestCreated|Q0
APIN -->|Request Data|DBSQL
APIN -->|RequestCreated|Q0
subgraph Schedulers
    SSVC0[SVC0]
    SSVC1[SVC1]
    SSVCN["SVC(n)"]
end
SCHEDDB@{ shape: lin-cyl, label: "SchedDb (SQL)" }
Q0 --> SSVC0
Q0 --> SSVC1
Q0 --> SSVCN
DBNOSQL@{ shape: lin-cyl, label: "Templates (NoSQL)" }
Q1@{ shape: bow-rect, label: "Processing Queue" }
SSVC0 & SSVC1 & SSVCN --> Q1
SSVC0 & SSVC1 & SSVCN <--> SCHEDDB
subgraph Engines
    ESVC0[SVC0]
    ESVC1[SVC1]
    ESVCN["SVC(n)"]
end
Q1 --> ESVC0 & ESVC1 & ESVCN
Q2@{ shape: bow-rect, label: "Error Queue" }
DBNOSQL --> ESVC0 & ESVC1 & ESVCN
Q3@{ shape: bow-rect, label: "Outbound Queue" }
ESVC0 & ESVC1 & ESVCN --> Q3
subgraph Processors
    PSVC0[SVC0]
    PSVC1[SVC1]
    PSVCN["SVC(n)"]
end
Q3 --> PSVC0 & PSVC1 & PSVCN
PSVC0 & PSVC1 & PSVCN --> Q2
ExternalBlobStorage --> PSVC0 & PSVC1 & PSVCN
Clients --> LoadBalancer
subgraph ExternalBlobStorage
    GENDOCS@{ shape: docs, label: "Generated documents" }
end
ESVC0 & ESVC1 & ESVCN --> ExternalBlobStorage
subgraph ExternalSmtp
SMTP[SMTP Provider]
end
subgraph ExternalMMS
MMS[MMS Provider]
end
PSVC0 & PSVC1 & PSVCN --> ExternalSmtp
PSVC0 & PSVC1 & PSVCN --> ExternalMMS
ExternalBlobStorage --> PSVC0 & PSVC1 & PSVCN
```