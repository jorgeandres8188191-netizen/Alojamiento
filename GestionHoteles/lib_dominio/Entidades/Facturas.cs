using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Facturas
    {
        [Key] public int Id { get; set; }
        public int? IdEstadoFactura { get; set; }
        public int? IdReservaHabitacion { get; set; }
        public int? Codigo { get; set; }
        public Decimal? SubTotal { get; set; }
        public Decimal? Total { get; set; }
        public DateTime? FechaPago { get; set; }

        [ForeignKey("IdEstadoFactura")] public EstadosFacturas? _EstadoFactura { get; set; }
        [ForeignKey("IdReservaHabitacion")] public ReservasHabitaciones? _ReservaHabitacion { get; set; }
    }
}
