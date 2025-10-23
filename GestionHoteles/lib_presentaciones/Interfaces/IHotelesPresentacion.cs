using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IHotelesPresentacion
    {
        Task<List<Hoteles>> Listar();
        Task<Hoteles?> Guardar(Hoteles? entidad);
        Task<Hoteles?> Modificar(Hoteles? entidad);
        Task<Hoteles?> Borrar(Hoteles? entidad);
    }
}
