using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class HotelesPrueba
    {
        private readonly IConexion? iConexion;
        private List<Hoteles>? lista;
        private Hoteles? entidad;
        public HotelesPrueba()
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
            this.lista = this.iConexion!.Hoteles!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            var TelefonosHoteles = this.iConexion.TelefonosHoteles.FirstOrDefault(x => x.Id == 1);
            entidad = EntidadesNucleo.Hoteles(TelefonosHoteles)!;
            this.iConexion!.Hoteles!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Nombre = "prueba-";
            var entry = this.iConexion!.Entry<Hoteles>(this.entidad);
            entry.State = EntityState.Modified; this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Hoteles!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}