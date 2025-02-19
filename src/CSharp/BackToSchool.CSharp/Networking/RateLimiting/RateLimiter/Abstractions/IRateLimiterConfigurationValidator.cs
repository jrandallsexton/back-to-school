using System.Collections.Generic;
using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Config;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions
{
    public interface IRateLimiterConfigurationValidator
    {
        (bool IsValid, List<string> Errors) Validate(RateLimiterConfiguration configuration);
    }
}
