using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;

using System;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Algorithms;

public class LeakyBucketConfiguration : IRateLimitAlgorithmConfiguration
{
    public int Capacity { get; init; }

    public TimeSpan Interval { get; init; }
}