using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Her projenin kendi servisleri olacak bunlarý bir bütün olarak sýnýflarý sadece buraya ekliyoruz

builder.Services.AddControllers();
//builder.Services.AddApplicationServices();
//builder.Services.AddSecurityServices();
builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddInfrastructureServices();
//builder.Services.AddHttpContextAccessor();









builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
