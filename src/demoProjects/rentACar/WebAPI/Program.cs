using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;

var builder = WebApplication.CreateBuilder(args);


// Her projenin kendi servisleri olacak bunlarý bir bütün olarak sýnýflarý sadece buraya ekliyoruz

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddSecurityServices(); // JWT
builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddInfrastructureServices(); // Dýþ Servis entegrasyonlarý için
builder.Services.AddHttpContextAccessor(); // JWT


TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>(); // TokenOption larý okumak için -appsettings.json içerisinden okur
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => // JWT için otantikasyon ejensikyonu ekleniyor. 
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };
});

builder.Services.AddSwaggerGen(opt => // Swagger için otantikasyon ejensikyonu ekleniyor. 
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345.54321\""
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
                { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            new string[] { }
        }
    });
});




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


app.UseAuthentication(); // Önce Yetkilendirme 
app.UseAuthorization();

app.MapControllers();

app.Run();
