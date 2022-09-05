// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.Graylog;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) => {
        services.AddHostedService<MessageBouncer>();
    })
    .UseSerilog(ConfigureLogger)
    .Build();


host.Run();

static void ConfigureLogger(HostBuilderContext host, LoggerConfiguration log) {
    log.MinimumLevel.Debug();
    log.WriteTo.Console();
    log.WriteTo.Graylog(new GraylogSinkOptions { HostnameOrAddress = "host.docker.internal", Port = 12201 });
    log.Enrich.WithProcessName();
}

