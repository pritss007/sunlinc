using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OntimeBackEnd.Models
{
    public class StudentModelRequest
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public int SerialNo { get; set; }
        public string StudentPrn { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Year { get; set; }
        public string Course { get; set; }
        public string School { get; set; }
        public string BoardingPoint { get; set; }
        public int TransportFee { get; set; }
        public string StartingPoint { get; set; }
        public bool Paid { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Batch {get; set; }
        public List<Attendance> Attendance { get; set; }
    }
    public class Attendance
    {
        public string Date { get; set; }
    }
    public class StudentModelResponse
    {
        public bool IsSuccess { get; set; }
        public string Message {  get; set; }
        public StudentModelRequest StudentModelRequest { get; set; }
    }
}
