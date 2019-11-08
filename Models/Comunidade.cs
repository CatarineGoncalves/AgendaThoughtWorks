using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITW.Models
{
    public partial class Comunidade
    {
        [Key]
        public int IdComunidade { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeResponsavel { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeComunidade { get; set; }
        [Required]
        [StringLength(100)]
        public string ContatoComunidade { get; set; }
        [StringLength(255)]
        public string FotoComunidade { get; set; }
        public int? IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Comunidade))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
