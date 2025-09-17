using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class TelefonosAcompañantesPrueba
    {
        private readonly IConexion? iConexion;
        private List<TelefonosAcompañantes>? lista;
        private TelefonosAcompañantes? entidad;
        public TelefonosAcompañantesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }
        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        public bool Listar()
        {
            this.lista = this.iConexion!.TelefonosAcompañantes!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.TelefonosAcompañantes()!;
            this.iConexion!.TelefonosAcompañantes!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Telefono = "prueba-";
            var entry = this.iConexion!.Entry<TelefonosAcompañantes>(this.entidad);
            entry.State = EntityState.Modified; this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.TelefonosAcompañantes!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}