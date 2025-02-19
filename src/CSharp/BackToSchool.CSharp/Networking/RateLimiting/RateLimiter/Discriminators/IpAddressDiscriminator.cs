﻿using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;
using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Discriminators;
using Microsoft.AspNetCore.Http;
using static BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Config.RateLimiterConfiguration;

namespace RateLimiter.Discriminators
{
    public class IpAddressDiscriminator(DiscriminatorConfiguration configuration) : IRateLimitDiscriminator
    {
        public DiscriminatorConfiguration Configuration { get; set; }

        public DiscriminatorEvaluationResult Evaluate(HttpContext context)
        {
            // TODO: This is likely incorrect. Cannot test b/c shows "localhost"
            var ipAddress = context.Request.Headers.Host.ToString();

            if (string.IsNullOrEmpty(configuration.DiscriminatorMatch) ||
                configuration.DiscriminatorMatch == "*")
                return new DiscriminatorEvaluationResult(configuration.Name)
                {
                    IsMatch = true,
                    MatchValue = ipAddress,
                    AlgorithmName = configuration.AlgorithmNames[0]
                };

            return configuration.DiscriminatorMatch == ipAddress ?
                new DiscriminatorEvaluationResult(configuration.Name)
                {
                    IsMatch = true,
                    MatchValue = ipAddress,
                    AlgorithmName = configuration.AlgorithmNames[0]
                } :
                new DiscriminatorEvaluationResult(configuration.Name)
                {
                    IsMatch = false,
                    MatchValue = ipAddress,
                    AlgorithmName = configuration.AlgorithmNames[0]
                };
        }
    }
}
