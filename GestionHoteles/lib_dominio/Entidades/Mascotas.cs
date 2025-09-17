using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Mascotas
    {
        [Key] public int Id { get; set; }
        public int? IdTipoMascota { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        [NotMapped] public ICollection<ReservasHabitaciones>? ReservasHabitaciones { get; set; }

        [ForeignKey("IdTipoMascota")] public TiposMascotas? _TipoMascota { get; set; }
    }
}
