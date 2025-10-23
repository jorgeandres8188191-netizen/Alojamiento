using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IAcompañantesPresentacion
    {
        Task<List<Acompañantes>> Listar();
        Task<Acompañantes?> Guardar(Acompañantes? entidad);
        Task<Acompañantes?> Modificar(Acompañantes? entidad);
        Task<Acompañantes?> Borrar(Acompañantes? entidad);
    }
}
