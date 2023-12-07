using Brete.Query.Api.Configuration;
using Brete.Query.Infrastructure.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.ConfigurePostgresSQLDatabase();

//Load Services
builder.ConfigureService();

//Load Queries
builder.ConfigureQuery();

builder.Services.AddControllers();
builder.Services.AddHostedService<ConsumerHostedService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
