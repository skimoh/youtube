//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System.ComponentModel.DataAnnotations;

namespace CodeBehind.SqlServer.Models
{
    public class Cliente
    {
        public string Id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; } = string.Empty;
    }
}
