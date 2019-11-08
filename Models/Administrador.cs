using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITW.Models
{
    public partial class Administrador
    {
        public Administrador()
        {
            Evento = new HashSet<Evento>();
        }

        [Key]
        public int IdAdministrador { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public int? IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Administrador))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        [InverseProperty("IdAdministradorNavigation")]
        public virtual ICollection<Evento> Evento { get; set; }
    }
}
