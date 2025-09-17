﻿using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;
namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ReservasPrueba
    {
        private readonly IConexion? iConexion;
        private List<Reservas>? lista;
        private Reservas? entidad;
        public ReservasPrueba()
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
            this.lista = this.iConexion!.Reservas!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            var Clientes = this.iConexion.Clientes.FirstOrDefault(x => x.Id == 1);
            entidad = EntidadesNucleo.Reservas(Clientes)!;
            this.iConexion!.Reservas!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.CheckIn = DateTime.Now;
            var entry = this.iConexion!.Entry<Reservas>(this.entidad);
            entry.State = EntityState.Modified; this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Reservas!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}