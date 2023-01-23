using StorageAPI_Manjula.BL;
using StorageAPI_Manjula.Services;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IBlobStorage, BlobStorage>();
builder.Services.AddScoped<ITableStorage, TableStorage>();
builder.Services.AddScoped<IQueueStorage, QueueStorage>();
builder.Services.AddScoped<IFileShareStorage, FileShareStorage>();
        
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
app.MapControllerRoute(name: "default", pattern: "{controller=WeatherForecast}/{action=Get}/{id?}");

app.Run();
