﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Shared.Repositories
{
    [Table("Usuario", Schema = "pamec")]
    public partial class Usuario
    {
        public Usuario()
        {
            FirmaUsuarios = new HashSet<FirmaUsuarios>();
            SeguimientoPAMEC = new HashSet<SeguimientoPAMEC>();
            Usuario_Cargo = new HashSet<Usuario_Cargo>();
        }

        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombres { get; set; }
        public int idTipoIdentificacion { get; set; }
        [Required]
        [StringLength(15)]
        public string numeroIdentificacion { get; set; }
        [Required]
        [StringLength(50)]
        public string telefono { get; set; }
        [Required]
        [StringLength(100)]
        public string correo { get; set; }
        [Required]
        [StringLength(100)]
        public string direccion { get; set; }
        public bool estado { get; set; }
        public int idTipoVinculacion { get; set; }
        public int idDependencia { get; set; }
        [Required]
        [StringLength(60)]
        public string apellidos { get; set; }
        [Key]
        public Guid idUsuario { get; set; }

        [ForeignKey(nameof(idDependencia))]
        [InverseProperty(nameof(Dependencia.Usuario))]
        public virtual Dependencia idDependenciaNavigation { get; set; }
        [ForeignKey(nameof(idTipoIdentificacion))]
        [InverseProperty(nameof(Constante.UsuarioidTipoIdentificacionNavigation))]
        public virtual Constante idTipoIdentificacionNavigation { get; set; }
        [ForeignKey(nameof(idTipoVinculacion))]
        [InverseProperty(nameof(Constante.UsuarioidTipoVinculacionNavigation))]
        public virtual Constante idTipoVinculacionNavigation { get; set; }
        [InverseProperty("id_userNavigation")]
        public virtual ICollection<FirmaUsuarios> FirmaUsuarios { get; set; }
        [InverseProperty("idVerificadorUNavigation")]
        public virtual ICollection<SeguimientoPAMEC> SeguimientoPAMEC { get; set; }
        [InverseProperty("idUserNavigation")]
        public virtual ICollection<Usuario_Cargo> Usuario_Cargo { get; set; }
    }
}