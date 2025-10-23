using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IMascotasPresentacion
    {
        Task<List<Mascotas>> Listar();
        Task<Mascotas?> Guardar(Mascotas? entidad);
        Task<Mascotas?> Modificar(Mascotas? entidad);
        Task<Mascotas?> Borrar(Mascotas? entidad);
    }
}
