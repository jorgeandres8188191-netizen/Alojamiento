using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IFacturasAplicacion
    {
        void Configurar(string StringConexion);
        List<Facturas> Listar();
        Facturas? Guardar(Facturas? entidad);
        Facturas? Modificar(Facturas? entidad);
        Facturas? Borrar(Facturas? entidad);
    }
}

