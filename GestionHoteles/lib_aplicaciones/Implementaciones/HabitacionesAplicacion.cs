﻿using lib_aplicaciones.Interfaces;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_aplicaciones.Implementaciones
{
    public class HabitacionesAplicacion : IHabitacionesAplicacion
    {
        private IConexion? IConexion = null;
        public HabitacionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Habitaciones? Borrar(Habitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Habitaciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Habitaciones? Guardar(Habitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            entidad!.Numero = 222;
            this.IConexion!.Habitaciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Habitaciones> Listar()
        {
            return this.IConexion!.Habitaciones!.Take(20).ToList();
        }
        public Habitaciones? Modificar(Habitaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            entidad!.Numero = 111;
            var entry = this.IConexion!.Entry<Habitaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}