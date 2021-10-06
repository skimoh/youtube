//***CODE BEHIND - BY RODOLFO.FONSECA***//
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeBehind.CosmoDB.Models
{
    public class Cliente
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "IdCliente")]
        public string IdCliente { get; set; }


        [JsonProperty(PropertyName = "Nome")]
        [Required, StringLength(50)]
        public string Nome { get; set; } = string.Empty;
    }
}
