using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IEstadosHabitacionesAplicacion
    {
        void Configurar(string StringConexion);
        List<EstadosHabitaciones> Listar();
        EstadosHabitaciones? Guardar(EstadosHabitaciones? entidad);
        EstadosHabitaciones? Modificar(EstadosHabitaciones? entidad);
        EstadosHabitaciones? Borrar(EstadosHabitaciones? entidad);
    }
}

