using System;
using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;

namespace RateLimiter.Common;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow()
    {
        return DateTime.UtcNow;
    }
}