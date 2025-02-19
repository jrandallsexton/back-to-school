using System.Collections.Concurrent;
using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Config;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions
{
    public interface IRateLimitAlgorithmProvider
    {
        ConcurrentDictionary<string, IRateLimitAlgorithm>
            GenerateAlgorithmsFromRules(RateLimiterConfiguration configuration);
    }
}
