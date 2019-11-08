using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITW.Models
{
    public partial class Sala
    {
        public Sala()
        {
            Evento = new HashSet<Evento>();
        }

        [Key]
        public int IdSala { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string Descricao { get; set; }

        [InverseProperty("IdSalaNavigation")]
        public virtual ICollection<Evento> Evento { get; set; }
    }
}
