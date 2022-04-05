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


builder.Services.AddDbContext<ByCDbContext>();

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

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(corsKey);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await using var scope = app.Services.CreateAsyncScope();
using var context = scope.ServiceProvider.GetService<ByCDbContext>();
await context.Database.MigrateAsync();

app.Run();
