using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Clientes
    {
        [Key] public int Id { get; set; }
        public int? IdTelefonoCliente { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Documento { get; set; }
        public string? Email { get; set; }

        [NotMapped] public ICollection<Reservas>? Reservas { get; set; }

        [ForeignKey("IdTelefonoCliente")] public TelefonosClientes? _TelefonoCliente { get; set; }
    }
}
