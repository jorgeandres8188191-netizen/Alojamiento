using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class MascotasPrueba
    {
        private readonly IConexion? iConexion;
        private List<Mascotas>? lista;
        private Mascotas? entidad;
        public MascotasPrueba()
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
            this.lista = this.iConexion!.Mascotas!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            var TiposMascotas = this.iConexion.TiposMascotas.FirstOrDefault(x => x.Id == 1);
            entidad = EntidadesNucleo.Mascotas(TiposMascotas)!;
            this.iConexion!.Mascotas!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Nombre = "prueba-";
            var entry = this.iConexion!.Entry<Mascotas>(this.entidad);
            entry.State = EntityState.Modified; this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Mascotas!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}