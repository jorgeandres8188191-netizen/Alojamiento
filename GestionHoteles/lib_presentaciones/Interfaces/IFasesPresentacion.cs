using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IFasesPresentacion
    {
        Task<List<Fases>> Listar();
        Task<Fases?> Guardar(Fases? entidad);
        Task<Fases?> Modificar(Fases? entidad);
        Task<Fases?> Borrar(Fases? entidad);
    }
}
