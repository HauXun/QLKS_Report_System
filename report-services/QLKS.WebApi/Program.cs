using QLKS.WebApi.Extensions;
using QLKS.WebApi.Mapsters;
using QLKS.WebApi.Validations;

var builder = WebApplication.CreateBuilder(args);
{
    //Add services to the container
    builder.ConfigureServices()
           .ConfigureCors()
           .ConfigureSwaggerOpenApi()
           .ConfigureMapster()
           .ConfigureFluentValidation();
}

var app = builder.Build();
{
    //Configure the HTTP request pipeline
    app.SetupRequestPipeLine();

    app.UseDataSeeder();

    //Configure API Endponts
    //app.MapSeederEndpoints();

    app.Run();
}