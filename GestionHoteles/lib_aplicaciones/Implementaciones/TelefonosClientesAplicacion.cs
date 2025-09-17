using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class TelefonosClientesAplicacion : ITelefonosClientesAplicacion
    {
        private IConexion? IConexion = null;
        public TelefonosClientesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public TelefonosClientes? Borrar(TelefonosClientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.TelefonosClientes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public TelefonosClientes? Guardar(TelefonosClientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Telefono = "Prueba";
            this.IConexion!.TelefonosClientes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<TelefonosClientes> Listar()
        {
            return this.IConexion!.TelefonosClientes!.Take(20).ToList();
        }
        public TelefonosClientes? Modificar(TelefonosClientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Telefono = "Prueba-";
            var entry = this.IConexion!.Entry<TelefonosClientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}