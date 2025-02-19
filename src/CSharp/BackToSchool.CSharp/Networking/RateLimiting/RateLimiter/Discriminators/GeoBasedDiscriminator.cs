using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Abstractions;
using BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Discriminators;
using Microsoft.AspNetCore.Http;
using static BackToSchool.CSharp.Networking.RateLimiting.RateLimiter.Config.RateLimiterConfiguration;

namespace RateLimiter.Discriminators
{
    public class GeoBasedDiscriminator(DiscriminatorConfiguration configuration) : IRateLimitDiscriminator
    {
        public DiscriminatorConfiguration Configuration { get; set; }

        public DiscriminatorEvaluationResult Evaluate(HttpContext context)
        {
            // get the ip address via cache/external source

            // perform a geo lookup on it

            // return the geolocation
            return new DiscriminatorEvaluationResult(configuration.Name)
            {
                IsMatch = false,
                MatchValue = "US"
            };
        }
    }
}
