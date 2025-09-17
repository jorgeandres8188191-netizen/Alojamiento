using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class ReservasHabitacionesAplicacion : IReservasHabitacionesAplicacion
    {
        private IConexion? IConexion = null;
        public ReservasHabitacionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public ReservasHabitaciones? Borrar(ReservasHabitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.ReservasHabitaciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public ReservasHabitaciones? Guardar(ReservasHabitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Codigo = 111;
            this.IConexion!.ReservasHabitaciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<ReservasHabitaciones> Listar()
        {
            return this.IConexion!.ReservasHabitaciones!.Take(20).ToList();
        }
        public ReservasHabitaciones? Modificar(ReservasHabitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Codigo = 222;
            var entry = this.IConexion!.Entry<ReservasHabitaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}