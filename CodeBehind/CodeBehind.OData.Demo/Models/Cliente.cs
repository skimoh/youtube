//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.ComponentModel.DataAnnotations;

namespace OData.Demo.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required, StringLength(11)]
        public string Telefone { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Documento { get; set; } = string.Empty;
    }
}
