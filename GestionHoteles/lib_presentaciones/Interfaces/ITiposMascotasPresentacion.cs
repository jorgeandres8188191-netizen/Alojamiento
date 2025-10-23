using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITiposMascotasPresentacion
    {
        Task<List<TiposMascotas>> Listar();
        Task<TiposMascotas?> Guardar(TiposMascotas? entidad);
        Task<TiposMascotas?> Modificar(TiposMascotas? entidad);
        Task<TiposMascotas?> Borrar(TiposMascotas? entidad);
    }
}
