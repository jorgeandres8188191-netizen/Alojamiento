using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IFacturasPresentacion
    {
        Task<List<Facturas>> Listar();
        Task<Facturas?> Guardar(Facturas? entidad);
        Task<Facturas?> Modificar(Facturas? entidad);
        Task<Facturas?> Borrar(Facturas? entidad);
    }
}
