using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITiposHabitacionesPresentacion
    {
        Task<List<TiposHabitaciones>> Listar();
        Task<TiposHabitaciones?> Guardar(TiposHabitaciones? entidad);
        Task<TiposHabitaciones?> Modificar(TiposHabitaciones? entidad);
        Task<TiposHabitaciones?> Borrar(TiposHabitaciones? entidad);
    }
}
