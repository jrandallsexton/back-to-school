using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Enums;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;

public interface IRateLimitAlgorithm
{
    string Name { get; init; }

    bool IsAllowed(string discriminator);

    AlgorithmType AlgorithmType { get; init; }
}