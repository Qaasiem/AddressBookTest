using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class AddressDetails
    {
        [BsonId]
        public ObjectId _id { get; set; } = ObjectId.GenerateNewId();

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public List<int> ContactNumber { get; set; }
        [Required]
        public List<string> EmailAddress { get; set; }
    }
}
