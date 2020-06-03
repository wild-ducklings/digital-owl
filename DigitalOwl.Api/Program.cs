using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace DigitalOwl.Api
{
// #pragma warning disable 1591
    public class Program
    {
        // private static void ConfigureLogging()
        // {
        //     var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        //     var configuration = new ConfigurationBuilder()
        //         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //         .AddJsonFile(
        //             $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        //             optional: true)
        //         .Build();
        //
        //     Log.Logger = new LoggerConfiguration()
        //         .Enrich.FromLogContext()
        //         .Enrich.WithMachineName()
        //         .WriteTo.Debug()
        //         .WriteTo.Console()
        //         // .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
        //         .Enrich.WithProperty("Environment", environment)
        //         .ReadFrom.Configuration(configuration)
        //         .CreateLogger();
        // }

        // private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration,
        //     string environment)
        // {
        //     return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
        //     {
        //         AutoRegisterTemplate = true,
        //         IndexFormat =
        //             $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
        //     };
        // }

        public static void Main(string[] args)
        {
            // ConfigureLogging();
            // try
            // {
            CreateHostBuilder(args).Build().Run();
            // }
            // catch (System.Exception ex)
            // {
            //     Log.Fatal($"Failed to start {Assembly.GetExecutingAssembly().GetName().Name}", ex);
            //     throw;
            // }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup.Startup>(); });

        // .ConfigureAppConfiguration(configuration =>
        // {
        //     configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //     configuration.AddJsonFile(
        //         $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        //         optional: true);
        // }).UseSerilog();
    }


// #pragma warning restore 1591
}