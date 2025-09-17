using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Hoteles
    {
        [Key] public int Id { get; set; }
        public int? IdTelefonoHotel { get; set; }
        public string? Direccion { get; set; }
        public string? Nombre { get; set; }
        public int? Calificacion { get; set; }

        [NotMapped] public ICollection<Habitaciones>? Habitaciones { get; set; }

        [ForeignKey("IdTelefonoHotel")] public TelefonosHoteles? _TelefonoHotel { get; set; }
    }
}
