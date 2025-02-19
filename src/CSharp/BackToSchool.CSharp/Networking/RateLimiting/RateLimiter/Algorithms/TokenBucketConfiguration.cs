using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Algorithms;

public class TokenBucketConfiguration : IRateLimitAlgorithmConfiguration
{
    public int MaxTokens { get; set; }

    public int RefillRatePerSecond { get; set; }
}