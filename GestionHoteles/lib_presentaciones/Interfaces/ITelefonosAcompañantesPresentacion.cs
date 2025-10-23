using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITelefonosAcompañantesPresentacion
    {
        Task<List<TelefonosAcompañantes>> Listar();
        Task<TelefonosAcompañantes?> Guardar(TelefonosAcompañantes? entidad);
        Task<TelefonosAcompañantes?> Modificar(TelefonosAcompañantes? entidad);
        Task<TelefonosAcompañantes?> Borrar(TelefonosAcompañantes? entidad);
    }
}
