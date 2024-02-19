using DataAccessLayer.Context;
using KonusarakOgrenStajProjesiAPI.Extensions;
using KonusarakOgrenStajProjesiAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<KonusarakOgrenStajProjesiDbContext>();

//Bagimliliklarin kontrolunu yapan extension servis burada eklenmistir.
builder.Services.ConfigureDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
