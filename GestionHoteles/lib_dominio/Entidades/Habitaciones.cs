using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Habitaciones
    {
        [Key] public int Id { get; set; }
        public int IdHotel { get; set; }
        public int? IdEstadoHabitacion { get; set; }
        public int? IdTipoHabitacion { get; set; }
        public int? Numero { get; set; }
        public int? Capacidad { get; set; }
        public int? Piso { get; set; }
        public Decimal? PrecioDia { get; set; }


        [NotMapped] public ICollection<ReservasHabitaciones>? ReservasHabitaciones { get; set; }

        [ForeignKey("IdHotel")] public Hoteles? _Hotel { get; set; }
        [ForeignKey("IdEstadoHabitacion")] public EstadosHabitaciones? _EstadoHabitacion { get; set; }
        [ForeignKey("IdTipoHabitacion")] public TelefonosHoteles? _TipoHabitacion { get; set; }

    }
}
