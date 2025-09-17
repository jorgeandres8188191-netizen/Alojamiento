using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class EstadosHabitacionesAplicacion : IEstadosHabitacionesAplicacion
    {
        private IConexion? IConexion = null;
        public EstadosHabitacionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public EstadosHabitaciones? Borrar(EstadosHabitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.EstadosHabitaciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public EstadosHabitaciones? Guardar(EstadosHabitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Descripcion = "Prueba";
            this.IConexion!.EstadosHabitaciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<EstadosHabitaciones> Listar()
        {
            return this.IConexion!.EstadosHabitaciones!.Take(20).ToList();
        }
        public EstadosHabitaciones? Modificar(EstadosHabitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Descripcion = "Prueba-";
            var entry = this.IConexion!.Entry<EstadosHabitaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}