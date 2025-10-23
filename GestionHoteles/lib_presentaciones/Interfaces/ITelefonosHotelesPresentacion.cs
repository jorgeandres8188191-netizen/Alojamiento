using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITelefonosHotelesPresentacion
    {
        Task<List<TelefonosHoteles>> Listar();
        Task<TelefonosHoteles?> Guardar(TelefonosHoteles? entidad);
        Task<TelefonosHoteles?> Modificar(TelefonosHoteles? entidad);
        Task<TelefonosHoteles?> Borrar(TelefonosHoteles? entidad);
    }
}
