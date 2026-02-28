using DS.Infrastructure.Postgres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddScoped<DirectoryServiseDbContext>(_ =>
    new DirectoryServiseDbContext(builder.Configuration.GetConnectionString("DsDb")!));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "DSPresenterAPI"));
}

app.MapControllers();

app.Run();