using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Reservas
    {
        [Key] public int Id { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        [NotMapped] public ICollection<ReservasHabitaciones>? ReservasHabitaciones { get; set; }

        [ForeignKey("IdCliente")] public Clientes? _Cliente { get; set; }
    }
}
