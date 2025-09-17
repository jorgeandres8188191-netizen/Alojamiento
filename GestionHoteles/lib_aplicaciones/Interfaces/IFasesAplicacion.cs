using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IFasesAplicacion
    {
        void Configurar(string StringConexion);
        List<Fases> Listar();
        Fases? Guardar(Fases? entidad);
        Fases? Modificar(Fases? entidad);
        Fases? Borrar(Fases? entidad);
    }
}

