using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IEstadosFacturasPresentacion
    {
        Task<List<EstadosFacturas>> Listar();
        Task<EstadosFacturas?> Guardar(EstadosFacturas? entidad);
        Task<EstadosFacturas?> Modificar(EstadosFacturas? entidad);
        Task<EstadosFacturas?> Borrar(EstadosFacturas? entidad);
    }
}
