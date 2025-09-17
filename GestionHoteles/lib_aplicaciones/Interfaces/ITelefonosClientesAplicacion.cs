using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface ITelefonosClientesAplicacion
    {
        void Configurar(string StringConexion);
        List<TelefonosClientes> Listar();
        TelefonosClientes? Guardar(TelefonosClientes? entidad);
        TelefonosClientes? Modificar(TelefonosClientes? entidad);
        TelefonosClientes? Borrar(TelefonosClientes? entidad);
    }
}
