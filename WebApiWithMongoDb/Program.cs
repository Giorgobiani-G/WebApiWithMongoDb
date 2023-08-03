using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApiWithMongoDb.Services;
using WebApiWithMongoDb.Services.Persons;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PersonDatabaseSettings>(
                builder.Configuration.GetSection(nameof(PersonDatabaseSettings)));

builder.Services.AddSingleton<IPersonDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<PersonDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("PersonDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IPersonService, PersonService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
