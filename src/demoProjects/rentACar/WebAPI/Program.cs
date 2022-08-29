using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);


// Her projenin kendi servisleri olacak bunlarý bir bütün olarak sýnýflarý sadece buraya ekliyoruz

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
//builder.Services.AddSecurityServices();
builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddInfrastructureServices();
//builder.Services.AddHttpContextAccessor();









builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// MiddleWare'i ekleyerek hata mesajýný düzeltiyorüz
if (app.Environment.IsProduction()) // Bunu açýklama satýrý yapýp çalýþtýrýrsak sadece hata mesajýnýn sade halini alýrýz ama bu þekilde çalýþtýrýrsak detaytlý bir þekilde hata mesajýný alýrýz
    app.ConfigureCustomExceptionMiddleware();



app.UseAuthorization();

app.MapControllers();

app.Run();
