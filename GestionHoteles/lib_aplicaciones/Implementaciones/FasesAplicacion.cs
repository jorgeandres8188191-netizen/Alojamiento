using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class FasesAplicacion : IFasesAplicacion
    {
        private IConexion? IConexion = null;
        public FasesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Fases? Borrar(Fases? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Fases!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Fases? Guardar(Fases? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Descripcion = "Prueba";
            this.IConexion!.Fases!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Fases> Listar()
        {
            return this.IConexion!.Fases!.Take(20).ToList();
        }
        public Fases? Modificar(Fases? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Descripcion = "Prueba-";
            var entry = this.IConexion!.Entry<Fases>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}