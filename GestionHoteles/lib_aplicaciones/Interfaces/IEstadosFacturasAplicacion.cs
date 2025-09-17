using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IEstadosFacturasAplicacion
    {
        void Configurar(string StringConexion);
        List<EstadosFacturas> Listar();
        EstadosFacturas? Guardar(EstadosFacturas? entidad);
        EstadosFacturas? Modificar(EstadosFacturas? entidad);
        EstadosFacturas? Borrar(EstadosFacturas? entidad);
    }
}
