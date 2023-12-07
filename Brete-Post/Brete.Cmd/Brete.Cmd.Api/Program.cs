using Brete.Cmd.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Load bson classes

BsonConfiguration.MapBsonClasses();

//Load Databases

builder.ConfigureMongoDatabase();
builder.ConfigureKafka();

//Load services

builder.Services.ConfigureService();

//Load commands

builder.ConfigureCommands();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
