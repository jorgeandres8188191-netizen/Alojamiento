using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class AcompañantesAplicacion : IAcompañantesAplicacion
    {
        private IConexion? IConexion = null;
        public AcompañantesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Acompañantes? Borrar(Acompañantes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Acompañantes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Acompañantes? Guardar(Acompañantes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Nombre = "Prueba";
            this.IConexion!.Acompañantes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Acompañantes> Listar()
        {
            return this.IConexion!.Acompañantes!.Take(20).ToList();
        }
        public Acompañantes? Modificar(Acompañantes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Nombre = "Prueba-";
            var entry = this.IConexion!.Entry<Acompañantes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}