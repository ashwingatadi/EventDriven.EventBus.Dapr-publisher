using EventDriven.EventBus.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dapr Event Bus
builder.Services.AddDaprEventBus(configuration);

// Add Dapr Mongo event cache
builder.Services.AddDaprMongoEventCache(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public record MessageCreatedEvent(string message) : IntegrationEvent;


