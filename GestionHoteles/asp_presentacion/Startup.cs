using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Presentaciones 
            services.AddScoped<IAcompañantesPresentacion, AcompañantesPresentacion>();
            services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
            services.AddScoped<IEstadosFacturasPresentacion, EstadosFacturasPresentacion>();
            services.AddScoped<IEstadosHabitacionesPresentacion, EstadosHabitacionesPresentacion>();
            services.AddScoped<IFacturasPresentacion, FacturasPresentacion>();
            services.AddScoped<IFasesPresentacion, FasesPresentacion>();
            services.AddScoped<IHabitacionesPresentacion, HabitacionesPresentacion>();
            services.AddScoped<IHotelesPresentacion, HotelesPresentacion>();
            services.AddScoped<IMascotasPresentacion, MascotasPresentacion>();
            services.AddScoped<IReservasPresentacion, ReservasPresentacion>();
            services.AddScoped<IReservasHabitacionesPresentacion, ReservasHabitacionesPresentacion>();
            services.AddScoped<ITelefonosAcompañantesPresentacion, TelefonosAcompañantesPresentacion>();
            services.AddScoped<ITelefonosClientesPresentacion, TelefonosClientesPresentacion>();
            services.AddScoped<ITelefonosHotelesPresentacion, TelefonosHotelesPresentacion>();
            services.AddScoped<ITiposHabitacionesPresentacion, TiposHabitacionesPresentacion>();
            services.AddScoped<ITiposMascotasPresentacion, TiposMascotasPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}