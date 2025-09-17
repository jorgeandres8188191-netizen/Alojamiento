using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface ITelefonosAcompañantesAplicacion
    {
        void Configurar(string StringConexion);
        List<TelefonosAcompañantes> Listar();
        TelefonosAcompañantes? Guardar(TelefonosAcompañantes? entidad);
        TelefonosAcompañantes? Modificar(TelefonosAcompañantes? entidad);
        TelefonosAcompañantes? Borrar(TelefonosAcompañantes? entidad);
    }
}
