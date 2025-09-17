using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class EstadosFacturasAplicacion : IEstadosFacturasAplicacion
    {
        private IConexion? IConexion = null;
        public EstadosFacturasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public EstadosFacturas? Borrar(EstadosFacturas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.EstadosFacturas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public EstadosFacturas? Guardar(EstadosFacturas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Descripcion = "Prueba";
            this.IConexion!.EstadosFacturas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<EstadosFacturas> Listar()
        {
            return this.IConexion!.EstadosFacturas!.Take(20).ToList();
        }
        public EstadosFacturas? Modificar(EstadosFacturas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Descripcion = "Prueba-";
            var entry = this.IConexion!.Entry<EstadosFacturas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}