using ByC.REST.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#if DEBUG
Environment.SetEnvironmentVariable("DB_CONN", "Server=localhost;Port=3307;DataBase=byc_db;Uid=root;Pwd=root");
#endif
var dbConn = Environment.GetEnvironmentVariable("DB_CONN");
builder.Services.AddDbContext<ByCDbContext>(opt => opt.UseMySql(dbConn, ServerVersion.AutoDetect(dbConn)));

const string corsKey = "ByCors";

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: corsKey,
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsKey);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
