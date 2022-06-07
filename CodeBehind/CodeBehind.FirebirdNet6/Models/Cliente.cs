//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBehind.FirebirdNet6.Models
{
    [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        public string Nome { get; set; }
    }
}
