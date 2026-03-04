using DS.Application;
using DS.Application.Database;
using DS.Domain.Constants;
using DS.Infrastructure.Database;
using DS.Infrastructure.Postgres;
using DS.Infrastructure.Postgres.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddScoped<DirectoryServiseDbContext>(_ =>
    new DirectoryServiseDbContext(builder.Configuration.GetConnectionString(Constants.ConnectionStringPostgres)!));

builder.Services.AddSingleton<IDbConnectionFactory, NpgsqlConnectionFactory>();

builder.Services.AddScoped<ILocationRepository, NpgSqlLocationsRepository>();
// builder.Services.AddScoped<ILocationRepository, EfCoreLocationRepository>();

builder.Services.AddScoped<CreateLocationHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "DSPresenterAPI"));
}

app.MapControllers();

app.Run();