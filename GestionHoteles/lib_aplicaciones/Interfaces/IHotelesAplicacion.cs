using lib_dominio.Entidades;
namespace lib_aplicaciones.Interfaces
{
    public interface IHotelesAplicacion
    {
        void Configurar(string StringConexion);
        List<Hoteles> Listar();
        Hoteles? Guardar(Hoteles? entidad);
        Hoteles? Modificar(Hoteles? entidad);
        Hoteles? Borrar(Hoteles? entidad);
    }
}

