using BisnessLogic.Data;
using BisnessLogic.Logic;
using CoreEntities.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MarketDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
  
});

builder.Services.AddControllers(); // Agrega el servicio AddControllers al contenedor de servicios

builder.Services.AddTransient<IProductoRepository, ProductoRepository>();


var app = builder.Build();
//creamo la instancia del que va a ejecutar el web api
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider; //instancia del servis provaider que nos permite ejecutar la migraci�n  e instanciar el divi context
    var loggerFactory = services.GetRequiredService<ILoggerFactory>(); // creamo un obj de tipo LoggerFactory para pder imprimir errores si aparece alguno

    try
    {
        var context = services.GetRequiredService<MarketDbContext>();//invocamos al divi context el cual es la instancia del entityframw 
         await context.Database.MigrateAsync(); // aqui ejecutamos la migraci�n
        await MarketDbContextData.CargarDataAsync(context, loggerFactory);
    }
    catch (Exception e)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(e, "Error en el proceso de migraci�n");
    }
}
//app.Run();

// Configure the HTTP request pipeline.

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateTime.Now.AddDays(index),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//});

app.UseRouting(); //permite que ASP.NET Core seleccione el controlador y la acci�n correctos en funci�n de la solicitud entrante

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Esto mapea las rutas de los controladores
});


app.Run();

//internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
