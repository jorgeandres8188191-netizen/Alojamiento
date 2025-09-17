using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class EstadosHabitaciones
    {
        [Key] public int Id { get; set; }
        public string? Descripcion { get; set; }

        [NotMapped] public ICollection<Habitaciones>? Habitaciones { get; set; }
    }
}
