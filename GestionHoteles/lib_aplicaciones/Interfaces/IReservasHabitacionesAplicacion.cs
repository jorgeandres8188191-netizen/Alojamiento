using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IReservasHabitacionesAplicacion
    {
        void Configurar(string StringConexion);
        List<ReservasHabitaciones> Listar();
        ReservasHabitaciones? Guardar(ReservasHabitaciones? entidad);
        ReservasHabitaciones? Modificar(ReservasHabitaciones? entidad);
        ReservasHabitaciones? Borrar(ReservasHabitaciones? entidad);
    }
}
