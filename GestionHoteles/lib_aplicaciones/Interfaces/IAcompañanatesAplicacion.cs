using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IAcompañantesAplicacion
    {
        void Configurar(string StringConexion);
        List<Acompañantes> Listar();
        Acompañantes? Guardar(Acompañantes? entidad);
        Acompañantes? Modificar(Acompañantes? entidad);
        Acompañantes? Borrar(Acompañantes? entidad);
    }
}