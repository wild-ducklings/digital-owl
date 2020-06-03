using System;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalOwl.Api.Startup
{
    [Obsolete("Deprecated i think so")]
    public static class RepositoriesRegister
    {
        public static void Register(IServiceCollection services)
        {
            // services.AddScoped<ITweetRepository, TweetRepository>();

        }
    }
}