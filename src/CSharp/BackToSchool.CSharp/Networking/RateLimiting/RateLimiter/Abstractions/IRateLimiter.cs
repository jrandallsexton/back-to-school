using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Config;

using Microsoft.AspNetCore.Http;

using System.Collections.Generic;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;

public interface IRateLimiter
{
    (bool RequestIsAllowed, string ErrorMessage) IsRequestAllowed(HttpContext context, IEnumerable<RateLimitedResource> rateLimitedResources);
}