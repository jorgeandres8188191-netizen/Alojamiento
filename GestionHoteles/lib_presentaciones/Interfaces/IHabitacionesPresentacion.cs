﻿using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IHabitacionesPresentacion
    {
        Task<List<Habitaciones>> Listar();
        Task<Habitaciones?> Guardar(Habitaciones? entidad);
        Task<Habitaciones?> Modificar(Habitaciones? entidad);
        Task<Habitaciones?> Borrar(Habitaciones? entidad);
    }
}
