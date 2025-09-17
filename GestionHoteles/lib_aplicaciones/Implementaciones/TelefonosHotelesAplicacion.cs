using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class TelefonosHotelesAplicacion : ITelefonosHotelesAplicacion
    {
        private IConexion? IConexion = null;
        public TelefonosHotelesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public TelefonosHoteles? Borrar(TelefonosHoteles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.TelefonosHoteles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public TelefonosHoteles? Guardar(TelefonosHoteles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Telefono = "Prueba";
            this.IConexion!.TelefonosHoteles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<TelefonosHoteles> Listar()
        {
            return this.IConexion!.TelefonosHoteles!.Take(20).ToList();
        }
        public TelefonosHoteles? Modificar(TelefonosHoteles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Telefono = "Prueba-";
            var entry = this.IConexion!.Entry<TelefonosHoteles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}