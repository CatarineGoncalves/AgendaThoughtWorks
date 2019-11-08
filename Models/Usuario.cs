using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITW.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Administrador = new HashSet<Administrador>();
            Comunidade = new HashSet<Comunidade>();
            Evento = new HashSet<Evento>();
            Funcionario = new HashSet<Funcionario>();
        }

        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        [InverseProperty(nameof(TipoUsuario.Usuario))]
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Administrador> Administrador { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Comunidade> Comunidade { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Evento> Evento { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}
