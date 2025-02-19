﻿using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;
using System;
using System.Collections.Concurrent;
using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Enums;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Algorithms;

public class FixedWindow : IRateLimitAlgorithm
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly int _maxRequests;
    private readonly TimeSpan _windowDuration;
    private readonly ConcurrentDictionary<string, (int Count, DateTime WindowStart)> _clientWindows;

    public FixedWindow(
        IDateTimeProvider dateTimeProvider,
        FixedWindowConfiguration configuration)
    {
        _dateTimeProvider = dateTimeProvider;
        _maxRequests = configuration.MaxRequests;
        _windowDuration = configuration.WindowDuration;
        _clientWindows = new ConcurrentDictionary<string, (int, DateTime)>();
    }

    public string Name { get; init; } = nameof(FixedWindow);

    public bool IsAllowed(string discriminator)
    {
        var now = _dateTimeProvider.UtcNow();

        // Atomically update or create a window for the client
        var window = _clientWindows.AddOrUpdate(
            discriminator,
            (1, now), // New client: start window with 1 request
            (_, existing) => now - existing.WindowStart >= _windowDuration ?
                // Window expired: reset count and start new window
                (1, now) :
                // Still in window: increment
                (existing.Count + 1, existing.WindowStart));

        return window.Count <= _maxRequests;
    }

    public AlgorithmType AlgorithmType { get; init; } = AlgorithmType.FixedWindow;
}