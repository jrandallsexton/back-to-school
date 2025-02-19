using System.Collections.Concurrent;
using System.Collections.Generic;
using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Config;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions
{
    public interface IRateLimitDiscriminatorProvider
    {
        ConcurrentDictionary<string, IRateLimitDiscriminator> GenerateDiscriminators(
            List<RateLimiterConfiguration.DiscriminatorConfiguration> configDiscriminators);
    }
}
