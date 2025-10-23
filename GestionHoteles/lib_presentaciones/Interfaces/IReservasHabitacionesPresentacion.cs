using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IReservasHabitacionesPresentacion
    {
        Task<List<ReservasHabitaciones>> Listar();
        Task<ReservasHabitaciones?> Guardar(ReservasHabitaciones? entidad);
        Task<ReservasHabitaciones?> Modificar(ReservasHabitaciones? entidad);
        Task<ReservasHabitaciones?> Borrar(ReservasHabitaciones? entidad);
    }
}
