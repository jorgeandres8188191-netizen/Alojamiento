using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class TiposHabitacionesAplicacion : ITiposHabitacionesAplicacion
    {
        private IConexion? IConexion = null;
        public TiposHabitacionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public TiposHabitaciones? Borrar(TiposHabitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.TiposHabitaciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public TiposHabitaciones? Guardar(TiposHabitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Descripcion = "Prueba";
            this.IConexion!.TiposHabitaciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<TiposHabitaciones> Listar()
        {
            return this.IConexion!.TiposHabitaciones!.Take(20).ToList();
        }
        public TiposHabitaciones? Modificar(TiposHabitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Descripcion = "Prueba-";
            var entry = this.IConexion!.Entry<TiposHabitaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}