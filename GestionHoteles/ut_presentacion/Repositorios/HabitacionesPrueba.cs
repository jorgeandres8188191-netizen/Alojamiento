﻿using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class HabitacionesPrueba
    {
        private readonly IConexion? iConexion;
        private List<Habitaciones>? lista;
        private Habitaciones? entidad;
        public HabitacionesPrueba()
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
            this.lista = this.iConexion!.Habitaciones!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            var EstadosHabitaciones = this.iConexion.EstadosHabitaciones.FirstOrDefault(x => x.Id == 1);
            var TiposHabitaciones = this.iConexion.TiposHabitaciones.FirstOrDefault(x => x.Id == 1);
            var Hoteles = this.iConexion.Hoteles.FirstOrDefault(x => x.Id == 1);
            entidad = EntidadesNucleo.Habitaciones(EstadosHabitaciones,Hoteles ,TiposHabitaciones)!;
            this.iConexion!.Habitaciones!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Numero = 101;
            var entry = this.iConexion!.Entry<Habitaciones>(this.entidad);
            entry.State = EntityState.Modified; this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Habitaciones!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}