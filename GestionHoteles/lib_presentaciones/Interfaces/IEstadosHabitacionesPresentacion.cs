using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IEstadosHabitacionesPresentacion
    {
        Task<List<EstadosHabitaciones>> Listar();
        Task<EstadosHabitaciones?> Guardar(EstadosHabitaciones? entidad);
        Task<EstadosHabitaciones?> Modificar(EstadosHabitaciones? entidad);
        Task<EstadosHabitaciones?> Borrar(EstadosHabitaciones? entidad);
    }
}
