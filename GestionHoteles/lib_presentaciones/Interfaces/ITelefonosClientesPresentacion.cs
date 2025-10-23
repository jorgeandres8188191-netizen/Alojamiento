using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITelefonosClientesPresentacion
    {
        Task<List<TelefonosClientes>> Listar();
        Task<TelefonosClientes?> Guardar(TelefonosClientes? entidad);
        Task<TelefonosClientes?> Modificar(TelefonosClientes? entidad);
        Task<TelefonosClientes?> Borrar(TelefonosClientes? entidad);
    }
}
