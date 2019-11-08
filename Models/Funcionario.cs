using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITW.Models
{
    public partial class Funcionario
    {
        [Key]
        public int IdFuncionario { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public int? IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Funcionario))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
