using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class TelefonosHotelesPrueba
    {
        private readonly IConexion? iConexion;
        private List<TelefonosHoteles>? lista;
        private TelefonosHoteles? entidad;
        public TelefonosHotelesPrueba()
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
            this.lista = this.iConexion!.TelefonosHoteles!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.TelefonosHoteles()!;
            this.iConexion!.TelefonosHoteles!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Telefono = "prueba-";
            var entry = this.iConexion!.Entry<TelefonosHoteles>(this.entidad);
            entry.State = EntityState.Modified; this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.TelefonosHoteles!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}