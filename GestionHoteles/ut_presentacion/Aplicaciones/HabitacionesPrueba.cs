using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class HabitacionesPrueba
    {
        private readonly IHabitacionesAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<Habitaciones>? lista;
        private Habitaciones? entidad;
        public HabitacionesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new HabitacionesAplicacion(iConexion);
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
            this.lista = this.iAplicacion!.Listar();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            var EstadosHabitaciones = this.iConexion.EstadosHabitaciones.FirstOrDefault(x => x.Id == 1);
            var Hoteles = this.iConexion.Hoteles.FirstOrDefault(x => x.Id == 1);
            var TiposHabitaciones = this.iConexion.TiposHabitaciones.FirstOrDefault(x => x.Id == 1);
            this.entidad = EntidadesNucleo.Habitaciones(EstadosHabitaciones, Hoteles, TiposHabitaciones)!;
            this.iAplicacion!.Guardar(this.entidad);
            return true;
        }
        public bool Modificar()
        {
            this.iAplicacion!.Modificar(this.entidad);
            return true;
        }
        public bool Borrar()
        {
            this.iAplicacion!.Borrar(this.entidad);
            return true;
        }
    }
}