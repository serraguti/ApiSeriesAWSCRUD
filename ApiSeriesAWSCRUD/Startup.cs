using Amazon.Lambda.Annotations;
using ApiSeriesAWSCRUD.Data;
using ApiSeriesAWSCRUD.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiSeriesAWSCRUD;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true);
        var configuration = builder.Build();
        services.AddSingleton<IConfiguration>(configuration);

        string connectionString =
            configuration.GetConnectionString("MySqlSeries");
        services.AddTransient<RepositorySeries>();
        services.AddDbContext<SeriesContext>
            (options => options.UseMySQL(connectionString));
    }
}
