using List.Microservice.Models;
using List.Microservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddScoped<IListDAL, ListDAL>();
builder.Services.AddDbContext<ListDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData(app);
}

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/list/add", ([FromServices] IListDAL db, ListModel list) =>
{
    db.AddToList(list);
});

app.MapGet("/list/get", ([FromServices] IListDAL db) =>
{
    return db.GetList();
});

app.MapGet("/list/entry/{id}", ([FromServices] IListDAL db, int id) =>
{
    return db.GetEntryById(id);
});

app.MapDelete("/list/delete/{id}", ([FromServices] IListDAL db, int id) =>
{
    db.DeleteEntryById(id);
});

app.Run();

public partial class Program { }
