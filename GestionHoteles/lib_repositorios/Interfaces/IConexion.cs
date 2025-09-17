using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Acompañantes>? Acompañantes { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<EstadosFacturas>? EstadosFacturas { get; set; }
        DbSet<EstadosHabitaciones>? EstadosHabitaciones { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<Fases>? Fases { get; set; }
        DbSet<Habitaciones>? Habitaciones { get; set; }
        DbSet<Hoteles>? Hoteles { get; set; }
        DbSet<Mascotas>? Mascotas { get; set; }
        DbSet<Reservas>? Reservas { get; set; }
        DbSet<ReservasHabitaciones>? ReservasHabitaciones { get; set; }
        DbSet<TelefonosAcompañantes>? TelefonosAcompañantes { get; set; }
        DbSet<TelefonosClientes>? TelefonosClientes { get; set; }
        DbSet<TelefonosHoteles>? TelefonosHoteles { get; set; }
        DbSet<TiposHabitaciones>? TiposHabitaciones { get; set; }
        DbSet<TiposMascotas>? TiposMascotas { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
