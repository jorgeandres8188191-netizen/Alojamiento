using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface ITiposMascotasAplicacion
    {
        void Configurar(string StringConexion);
        List<TiposMascotas> Listar();
        TiposMascotas? Guardar(TiposMascotas? entidad);
        TiposMascotas? Modificar(TiposMascotas? entidad);
        TiposMascotas? Borrar(TiposMascotas? entidad);
    }
}
