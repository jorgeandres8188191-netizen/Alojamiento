using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IReservasPresentacion
    {
        Task<List<Reservas>> Listar();
        Task<Reservas?> Guardar(Reservas? entidad);
        Task<Reservas?> Modificar(Reservas? entidad);
        Task<Reservas?> Borrar(Reservas? entidad);
    }
}
