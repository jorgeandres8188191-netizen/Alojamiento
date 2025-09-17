using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Acompañantes>? Acompañantes { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<EstadosFacturas>? EstadosFacturas { get; set; }
        public DbSet<EstadosHabitaciones>? EstadosHabitaciones { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Fases>? Fases { get; set; }
        public DbSet<Habitaciones>? Habitaciones { get; set; }
        public DbSet<Hoteles>? Hoteles { get; set; }
        public DbSet<Mascotas>? Mascotas { get; set; }
        public DbSet<Reservas>? Reservas { get; set; }
        public DbSet<ReservasHabitaciones>? ReservasHabitaciones { get; set; }
        public DbSet<TelefonosAcompañantes>? TelefonosAcompañantes { get; set; }
        public DbSet<TelefonosClientes>? TelefonosClientes { get; set; }
        public DbSet<TelefonosHoteles>? TelefonosHoteles { get; set; }
        public DbSet<TiposHabitaciones>? TiposHabitaciones { get; set; }
        public DbSet<TiposMascotas>? TiposMascotas { get; set; }
    }
}