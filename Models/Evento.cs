using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITW.Models
{
    public partial class Evento
    {
        [Key]
        public int IdEvento { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeEvento { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataEvento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime HoraEvento { get; set; }
        [Required]
        [StringLength(255)]
        public string Descricao { get; set; }
        [Required]
        [MaxLength(1)]
        public byte[] Libras { get; set; }
        public int QuantidadeP { get; set; }
        [Required]
        [Column("URLSite")]
        [StringLength(255)]
        public string Urlsite { get; set; }
        [Required]
        [MaxLength(1)]
        public byte[] Alimentacao { get; set; }
        [Required]
        [StringLength(220)]
        public string RestricaoAlimentacao { get; set; }
        [StringLength(50)]
        public string Localizacao { get; set; }
        [StringLength(100)]
        public string Requisicao { get; set; }
        public int IdCategoria { get; set; }
        public int IdSala { get; set; }
        public int? IdAdministrador { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdAdministrador))]
        [InverseProperty(nameof(Administrador.Evento))]
        public virtual Administrador IdAdministradorNavigation { get; set; }
        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(Categoria.Evento))]
        public virtual Categoria IdCategoriaNavigation { get; set; }
        [ForeignKey(nameof(IdSala))]
        [InverseProperty(nameof(Sala.Evento))]
        public virtual Sala IdSalaNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Evento))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public object NomeComunidade { get; internal set; }
    }
}
