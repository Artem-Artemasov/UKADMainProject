﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;


namespace LinkFounder.DbSaver
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            var linkViewer = host.Services.GetService<LinkViewerApp>();
            linkViewer.Start();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            {
                services.AddEfRepository<LinkFounderDbContext>(options => options.UseSqlServer(@"Server=DESKTOP-BFO0R26; Database=LinkFounder; Trusted_Connection=True"));
                services.AddScoped<LinkViewerApp>();
                services.AddScoped<DataSaver>();
            }).
            ConfigureLogging(options => options.SetMinimumLevel(LogLevel.Error));
    }
}
