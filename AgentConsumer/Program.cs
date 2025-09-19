using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
/// <summary> Định nghĩa điểm vào của ứng dụng </summary>
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<FaceAgentWorker>();
    })
    .Build();

await host.RunAsync();
