using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class TelefonosClientes
    {
        [Key] public int Id { get; set; }
        public string? Telefono { get; set; }

        [NotMapped] public ICollection<Clientes>? Clientes { get; set; }
    }
}
