using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Config;
using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Discriminators;

using Microsoft.AspNetCore.Http;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;

public interface IRateLimitDiscriminator
{
    RateLimiterConfiguration.DiscriminatorConfiguration Configuration { get; set; }

    DiscriminatorEvaluationResult Evaluate(HttpContext context);
}