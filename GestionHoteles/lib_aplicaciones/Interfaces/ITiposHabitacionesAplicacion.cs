using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface ITiposHabitacionesAplicacion
    {
        void Configurar(string StringConexion);
        List<TiposHabitaciones> Listar();
        TiposHabitaciones? Guardar(TiposHabitaciones? entidad);
        TiposHabitaciones? Modificar(TiposHabitaciones? entidad);
        TiposHabitaciones? Borrar(TiposHabitaciones? entidad);
    }
}
