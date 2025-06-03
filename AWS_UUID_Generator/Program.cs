namespace AWS_UUID_Generator;

public class Program
{
    public static void Main(string[] args)
    {
        // Solo ejecuta localmente
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}