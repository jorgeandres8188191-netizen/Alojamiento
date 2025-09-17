using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class TiposMascotasAplicacion : ITiposMascotasAplicacion
    {
        private IConexion? IConexion = null;
        public TiposMascotasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public TiposMascotas? Borrar(TiposMascotas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.TiposMascotas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public TiposMascotas? Guardar(TiposMascotas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Nombre = "Prueba";
            this.IConexion!.TiposMascotas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<TiposMascotas> Listar()
        {
            return this.IConexion!.TiposMascotas!.Take(20).ToList();
        }
        public TiposMascotas? Modificar(TiposMascotas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Nombre = "Prueba-";
            var entry = this.IConexion!.Entry<TiposMascotas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}