using RestWithASPNET10Erudio.Configurations;
using RestWithASPNET10Erudio.Service;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
