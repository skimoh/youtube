//***CODE BEHIND - BY RODOLFO.FONSECA***//
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeBehind.Mongo.Models
{
    public class Cliente
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public string Id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; } = string.Empty;
    }
}
