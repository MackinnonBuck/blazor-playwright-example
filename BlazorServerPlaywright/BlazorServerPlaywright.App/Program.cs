using BlazorServerPlaywright.App;

public class Program
{
    private static async Task Main(string[] args)
    {
        var host = BuildWebHost(args);
        await host.RunAsync();
    }

    public static IHost BuildWebHost(string[]? args = default)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder =>
            {
                builder.UseStaticWebAssets();
                builder.UseStartup<Startup>();
            })
            .Build();
}
