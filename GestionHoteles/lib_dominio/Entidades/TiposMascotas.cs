using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class TiposMascotas
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Raza { get; set; }

        [NotMapped] public ICollection<Mascotas>? Mascotas { get; set; }
    }
}
