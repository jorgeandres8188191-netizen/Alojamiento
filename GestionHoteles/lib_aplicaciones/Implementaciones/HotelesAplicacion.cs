using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class HotelesAplicacion : IHotelesAplicacion
    {
        private IConexion? IConexion = null;
        public HotelesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Hoteles? Borrar(Hoteles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Hoteles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Hoteles? Guardar(Hoteles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Nombre = "Prueba";
            this.IConexion!.Hoteles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Hoteles> Listar()
        {
            return this.IConexion!.Hoteles!.Take(20).ToList();
        }
        public Hoteles? Modificar(Hoteles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Nombre = "Prueba-";
            var entry = this.IConexion!.Entry<Hoteles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}