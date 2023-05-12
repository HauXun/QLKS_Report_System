using Carter;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLKS.Data.Contextp;
using QLKS.Data.Seeders;
using QLKS.Services.Reports;
using System.Text.Json.Serialization;

namespace QLKS.WebApi.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddOptions();
        builder.Services.AddAuthentication(o =>
        {
            o.DefaultScheme = IdentityConstants.ApplicationScheme;
            o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
        .AddIdentityCookies(o => { });
        builder.Services.AddAuthorization();

        builder.Services.AddMemoryCache();

        builder.Services.AddCarter();

        builder.Services.AddDbContext<ReportDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddScoped<IReportRepository, ReportRepository>();

        builder.Services.AddScoped<IDataSeeder, DataSeeder>();
        //builder.Logging.ClearProviders();

        return builder;
    }

    public static WebApplicationBuilder ConfigureCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("QlksReport", policyBuilder => policyBuilder.AllowAnyOrigin()
                                                                          .AllowAnyHeader()
                                                                          .AllowAnyMethod());
        });

        return builder;
    }

    public static WebApplicationBuilder ConfigureSwaggerOpenApi(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllersWithViews()
                        .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        return builder;
    }

    public static WebApplication SetupRequestPipeLine(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("QlksReport");

        app.MapCarter();

        return app;
    }

    // Thêm dữ liệu mẫu vào CSDL
    public static IApplicationBuilder UseDataSeeder(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        try
        {
            scope.ServiceProvider.GetRequiredService<IDataSeeder>().Initialize();
        }
        catch (Exception ex)
        {
            scope.ServiceProvider.GetRequiredService<ILogger<Program>>().LogError(ex, "Could not insert data into database");
        }

        return app;
    }
}
