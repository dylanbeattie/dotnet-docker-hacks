# dotnet-docker-hacks
Experiments running .NET in Docker containers

to build it:

docker build -t bouncer .

To run it:

docker run bouncer

Note that inside the Bouncer app, the Graylog sink is set to:

```
static void ConfigureLogger(HostBuilderContext host, LoggerConfiguration log) {
    log.MinimumLevel.Debug();
    log.WriteTo.Console();
    log.WriteTo.Graylog(new GraylogSinkOptions { HostnameOrAddress = "host.docker.internal", Port = 12201 });
    log.Enrich.WithProcessName();
}
```