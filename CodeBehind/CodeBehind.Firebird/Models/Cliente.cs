//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System.ComponentModel.DataAnnotations;

namespace CodeBehind.Firebird.Models
{
    public class CLIENTE
    {
        [Key, StringLength(100)]
        public string ID { get; set; }

        [StringLength(100)]
        public string NOME { get; set; } = string.Empty;
    }
}
