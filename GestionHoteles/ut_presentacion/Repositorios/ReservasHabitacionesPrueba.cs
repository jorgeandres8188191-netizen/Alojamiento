using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ReservasHabitacionesPrueba
    {
        private readonly IConexion? iConexion;
        private List<ReservasHabitaciones>? lista;
        private ReservasHabitaciones? entidad;
        public ReservasHabitacionesPrueba()
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
            this.lista = this.iConexion!.ReservasHabitaciones!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            var Habitaciones = this.iConexion.Habitaciones.FirstOrDefault(x => x.Id == 1);
            var Reservas = this.iConexion.Reservas.FirstOrDefault(x => x.Id == 1);
            var Fases = this.iConexion.Fases.FirstOrDefault(x => x.Id == 1);
            var Acompañantes = this.iConexion.Acompañantes.FirstOrDefault(x => x.Id == 1);
            var Mascotas = this.iConexion.Mascotas.FirstOrDefault(x => x.Id == 1);
            entidad = EntidadesNucleo.ReservasHabitaciones(Habitaciones, Reservas, Fases, Acompañantes, Mascotas)!;
            this.iConexion!.ReservasHabitaciones!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Codigo = 111;
            var entry = this.iConexion!.Entry<ReservasHabitaciones>(this.entidad);
            entry.State = EntityState.Modified; this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.ReservasHabitaciones!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}