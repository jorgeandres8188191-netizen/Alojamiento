using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Acompañantes
    {
        [Key] public int Id { get; set; }
        public int? IdTelefonoAcompañante { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Documento { get; set; }
        public string? Email { get; set; }

        [NotMapped] public ICollection<ReservasHabitaciones>? ReservasHabitaciones { get; set; }

        [ForeignKey("IdTelefonoAcompañante")] public TelefonosAcompañantes? _TelefonoAcompañante { get; set; }
    }
}
