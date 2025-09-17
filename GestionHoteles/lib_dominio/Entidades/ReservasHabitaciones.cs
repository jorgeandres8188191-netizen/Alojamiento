using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class ReservasHabitaciones
    {
        [Key] public int Id { get; set; }
        public int IdHabitacion { get; set; }
        public int IdReserva { get; set; }
        public int? IdFase { get; set; }
        public int? IdAcompañante { get; set; }
        public int? IdMascota { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Codigo { get; set; }

        [NotMapped] public ICollection<Facturas>? Facturas { get; set; }

        [ForeignKey("IdHabitacion")] public Habitaciones? _Habitacion { get; set; }
        [ForeignKey("IdReserva")] public Reservas? _Reserva { get; set; }
        [ForeignKey("IdFase")] public Fases? _Fase { get; set; }
        [ForeignKey("IdAcompañante")] public Acompañantes? _Acompañante { get; set; }
        [ForeignKey("IdMascota")] public Mascotas? _Mascota { get; set; }
    }
}
