using MongoTest;

var builder = Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.ConfigureKestrel(options => { });
        webBuilder.UseStartup<Startup>();
    });

builder.Build().Run();
