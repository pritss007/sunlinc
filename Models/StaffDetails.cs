using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace OntimeBackEnd.Models
{

    public class StaffDetailsRequest
    {
         [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string StaffId { get; set; }
        public string Name { get; set; }
        public string Institute { get; set; }
        public string BoardingPoint { get; set; }
        public string Password { get; set; }
        public string Fees { get; set; }
    }
    public class StaffModelResponse
    {
        public bool IsSuccess { get; set; }
        public string Message {  get; set; }
        public List<StaffDetailsRequest> StaffDetailsRequest { get; set; }
    }
    public class StaffRecord
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public StaffDetailsRequest StaffDetailsRequest { get; set; }
    }
}
