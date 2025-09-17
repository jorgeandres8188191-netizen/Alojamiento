using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Aplicaciones
{
    [TestClass]
    public class ReservasHabitacionesPrueba
    {
        private readonly IReservasHabitacionesAplicacion? iAplicacion;
        private readonly IConexion? iConexion;
        private List<ReservasHabitaciones>? lista;
        private ReservasHabitaciones? entidad;
        public ReservasHabitacionesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            iAplicacion = new ReservasHabitacionesAplicacion(iConexion);
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
            var Habitaciones = this.iConexion.Habitaciones.FirstOrDefault(x => x.Id == 1);
            var Reservas = this.iConexion.Reservas.FirstOrDefault(x => x.Id == 1);
            var Fases = this.iConexion.Fases.FirstOrDefault(x => x.Id == 1);
            var Acompañantes = this.iConexion.Acompañantes.FirstOrDefault(x => x.Id == 1);
            var Mascotas = this.iConexion.Mascotas.FirstOrDefault(x => x.Id == 1);
            this.entidad = EntidadesNucleo.ReservasHabitaciones(Habitaciones, Reservas, Fases, Acompañantes, Mascotas)!;
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
