using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class TelefonosAcompañantesAplicacion : ITelefonosAcompañantesAplicacion
    {
        private IConexion? IConexion = null;
        public TelefonosAcompañantesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public TelefonosAcompañantes? Borrar(TelefonosAcompañantes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.TelefonosAcompañantes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public TelefonosAcompañantes? Guardar(TelefonosAcompañantes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Telefono = "Prueba";
            this.IConexion!.TelefonosAcompañantes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<TelefonosAcompañantes> Listar()
        {
            return this.IConexion!.TelefonosAcompañantes!.Take(20).ToList();
        }
        public TelefonosAcompañantes? Modificar(TelefonosAcompañantes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Telefono = "Prueba-";
            var entry = this.IConexion!.Entry<TelefonosAcompañantes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}