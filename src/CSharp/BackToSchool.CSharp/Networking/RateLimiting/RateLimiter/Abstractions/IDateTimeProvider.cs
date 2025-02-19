using System;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;

public interface IDateTimeProvider
{
    DateTime UtcNow();
}