using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface ITelefonosHotelesAplicacion
    {
        void Configurar(string StringConexion);
        List<TelefonosHoteles> Listar();
        TelefonosHoteles? Guardar(TelefonosHoteles? entidad);
        TelefonosHoteles? Modificar(TelefonosHoteles? entidad);
        TelefonosHoteles? Borrar(TelefonosHoteles? entidad);
    }
}
