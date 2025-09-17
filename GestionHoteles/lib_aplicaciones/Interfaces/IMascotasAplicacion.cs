using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IMascotasAplicacion
    {
        void Configurar(string StringConexion);
        List<Mascotas> Listar();
        Mascotas? Guardar(Mascotas? entidad);
        Mascotas? Modificar(Mascotas? entidad);
        Mascotas? Borrar(Mascotas? entidad);
    }
}

