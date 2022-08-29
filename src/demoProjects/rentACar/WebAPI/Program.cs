using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);


// Her projenin kendi servisleri olacak bunlar� bir b�t�n olarak s�n�flar� sadece buraya ekliyoruz

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

// MiddleWare'i ekleyerek hata mesaj�n� d�zeltiyor�z
if (app.Environment.IsProduction()) // Bunu a��klama sat�r� yap�p �al��t�r�rsak sadece hata mesaj�n�n sade halini al�r�z ama bu �ekilde �al��t�r�rsak detaytl� bir �ekilde hata mesaj�n� al�r�z
    app.ConfigureCustomExceptionMiddleware();



app.UseAuthorization();

app.MapControllers();

app.Run();
