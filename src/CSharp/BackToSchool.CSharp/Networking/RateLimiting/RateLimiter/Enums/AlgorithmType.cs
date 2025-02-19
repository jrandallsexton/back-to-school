namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Enums;

public enum AlgorithmType
{
    Default,
    FixedWindow,
    LeakyBucket,
    SlidingWindow,
    TimespanElapsed,
    TokenBucket
}