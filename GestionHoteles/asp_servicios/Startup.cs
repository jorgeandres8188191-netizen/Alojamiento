using asp_servicios.Controllers; 
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Implementaciones; 
using lib_repositorios.Interfaces; 
using Microsoft.AspNetCore.Server.Kestrel.Core; 
 
namespace asp_servicios 
{ 
    public class Startup 
    { 
        public Startup(IConfiguration configuration) 
        { 
            Configuration = configuration; 
        } 
 
        public static IConfiguration? Configuration { set; get; } 
 
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection 
services) 
        { 
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; 
}); 
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; }); 
            services.AddControllers(); 
            services.AddEndpointsApiExplorer(); 
            //services.AddSwaggerGen(); 
            // Repositorios 
            services.AddScoped<IConexion, Conexion>(); 
            services.AddScoped<IAcompañantesAplicacion, AcompañantesAplicacion>();
            services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
            services.AddScoped<IEstadosFacturasAplicacion, EstadosFacturasAplicacion>();
            services.AddScoped<IEstadosHabitacionesAplicacion, EstadosHabitacionesAplicacion>();
            services.AddScoped<IFacturasAplicacion, FacturasAplicacion>();
            services.AddScoped<IFasesAplicacion,FasesAplicacion>();
            services.AddScoped<IHabitacionesAplicacion, HabitacionesAplicacion>();
            services.AddScoped<IHotelesAplicacion, HotelesAplicacion>();
            services.AddScoped<IMascotasAplicacion, MascotasAplicacion>();
            services.AddScoped<IReservasAplicacion, ReservasAplicacion>();
            services.AddScoped<IReservasHabitacionesAplicacion, ReservasHabitacionesAplicacion>();
            services.AddScoped<ITelefonosAcompañantesAplicacion, TelefonosAcompañantesAplicacion>();
            services.AddScoped<ITelefonosClientesAplicacion, TelefonosClientesAplicacion>();
            services.AddScoped<ITelefonosHotelesAplicacion, TelefonosHotelesAplicacion>();
            services.AddScoped<ITiposHabitacionesAplicacion, TiposHabitacionesAplicacion>();
            services.AddScoped<ITiposMascotasAplicacion, TiposMascotasAplicacion>();
            // Controladores 
            services.AddScoped<TokenController, TokenController>(); 
 
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin())); 
        } 
 
        public void Configure(WebApplication app, IWebHostEnvironment env) 
        { 
            if (env.IsDevelopment()) 
            { 
                //app.UseSwagger(); 
                //app.UseSwaggerUI(); 
            } 
            app.UseHttpsRedirection(); 
            app.UseAuthorization(); 
            app.MapControllers(); 
            app.Run(); 
            app.UseRouting(); 
            app.UseCors(); 
        } 
    } 
}