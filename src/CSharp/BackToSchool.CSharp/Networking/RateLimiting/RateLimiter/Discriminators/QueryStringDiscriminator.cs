using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;
using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Discriminators;
using Microsoft.AspNetCore.Http;
using static BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Config.RateLimiterConfiguration;

namespace RateLimiter.Discriminators
{
    public class QueryStringDiscriminator(DiscriminatorConfiguration configuration) : IRateLimitDiscriminator
    {
        public DiscriminatorConfiguration Configuration { get; set; }

        public DiscriminatorEvaluationResult Evaluate(HttpContext context)
        {
            if (string.IsNullOrEmpty(configuration.DiscriminatorKey))
            {
                // likely should log and throw
                return new DiscriminatorEvaluationResult(configuration.Name);
            }

            if (!context.Request.Query.TryGetValue(configuration.DiscriminatorKey, out var value))
            {
                return new DiscriminatorEvaluationResult(configuration.Name);
            }

            if (string.IsNullOrEmpty(configuration.DiscriminatorMatch) ||
                configuration.DiscriminatorMatch == "*")
                return new DiscriminatorEvaluationResult(configuration.Name)
                {
                    IsMatch = true,
                    MatchValue = value.ToString()
                };

            return configuration.DiscriminatorMatch == value.ToString() ?
                new DiscriminatorEvaluationResult(configuration.Name)
                {
                    IsMatch = true,
                    MatchValue = value.ToString()
                } :
                new DiscriminatorEvaluationResult(configuration.Name)
                {
                    IsMatch = false,
                    MatchValue = value.ToString()
                };
        }
    }
}
