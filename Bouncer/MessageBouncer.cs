// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class MessageBouncer : IHostedService {
    private readonly ILogger<MessageBouncer> logger;

    public MessageBouncer(ILogger<MessageBouncer> logger) {
        this.logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken) {
        logger.LogInformation("Starting Bouncer worker service...");
        logger.LogInformation("We're running in Docker now! Wooo!");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) {
        logger.LogInformation("Stopping Bouncer worker service...");
        return Task.CompletedTask;
    }
}

