using BisnessLogic.Data;
using BisnessLogic.Logic;
using CoreEntities.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfiles)); // llamamos  MappingProfiles creado en WebApi Dtos
builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>))); //se crea un objeto de tipo GenericRepository por cada Riquest  que envie el cliente
// Add services to the container.
builder.Services.AddDbContext<MarketDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers(); // Agrega el servicio AddControllers al contenedor de servicios

builder.Services.AddTransient<IProductoRepository, ProductoRepository>();

var app = builder.Build();
//creamo la instancia del que va a ejecutar el web api
app.UseStatusCodePagesWithReExecute("/errors", "?code={0}");

app.UseMiddleware<ExceptionMiddleware>();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider; //instancia del servis provaider que nos permite ejecutar la migración  e instanciar el divi context
    var loggerFactory = services.GetRequiredService<ILoggerFactory>(); // creamo un obj de tipo LoggerFactory para pder imprimir errores si aparece alguno

    try
    {
        var context = services.GetRequiredService<MarketDbContext>();//invocamos al divi context el cual es la instancia del entityframw
        await context.Database.MigrateAsync(); // aqui ejecutamos la migración
        await MarketDbContextData.CargarDataAsync(context, loggerFactory);
    }
    catch (Exception e)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(e, "Error en el proceso de migración");
    }
}

app.UseRouting(); //permite que ASP.NET Core seleccione el controlador y la acción correctos en función de la solicitud entrante

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Esto mapea las rutas de los controladores
});

app.Run();