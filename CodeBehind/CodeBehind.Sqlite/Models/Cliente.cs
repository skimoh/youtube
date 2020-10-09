//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeBehind.Sqlite.Models
{
    public class Cliente
    {
        [Key]
        public string Id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; } = string.Empty;
    }
}
