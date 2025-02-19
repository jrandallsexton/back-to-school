﻿using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;
using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Config;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;

using System.Linq;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Middleware;

public class RateLimiterMiddleware
{
    private readonly ILogger<RateLimiterMiddleware> _logger;
    private readonly RequestDelegate _next;
    private readonly IRateLimiter _rateLimiter;

    public RateLimiterMiddleware(
        ILogger<RateLimiterMiddleware> logger,
        RequestDelegate next,
        IRateLimiter rateLimiter)
    {
        _logger = logger;
        _next = next;
        _rateLimiter = rateLimiter;
    }

    public async Task Invoke(HttpContext context)
    {
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;

        var rateLimitedResources = endpoint?.Metadata.GetOrderedMetadata<RateLimitedResource>();

        if (rateLimitedResources is not null && rateLimitedResources.Any())
        {
            var (isAllowed, message) = _rateLimiter.IsRequestAllowed(context, rateLimitedResources);

            if (!isAllowed)
            {
                _logger.LogWarning("Client was rate limited with {@Message}", message);
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                await context.Response.WriteAsync(message);
                return;
            }
        }

        await _next(context);
    }
}