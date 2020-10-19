//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System.ComponentModel.DataAnnotations;

namespace CodeBehind.Maria.Models
{
    public class Cliente
    {
        public string Id { get; set; }

        [Required, StringLength(10)]
        public string Nome { get; set; } = string.Empty;
    }
}
