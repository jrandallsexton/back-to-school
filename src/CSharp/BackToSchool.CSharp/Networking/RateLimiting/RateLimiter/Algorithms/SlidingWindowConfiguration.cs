﻿using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;

using System;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Algorithms;

public class SlidingWindowConfiguration : IRateLimitAlgorithmConfiguration
{
    public int MaxRequests { get; init; }

    public TimeSpan WindowDuration { get; init; }
}