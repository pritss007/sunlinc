using MongoDB.Bson.Serialization.Attributes;

namespace OntimeBackEnd.Models
{
    public class BusDetails
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string HotelJatra1 { get; set; }
            public string Mharsul2 { get; set; }
            public string Indraprasth3 { get; set; }
            public string Nimani4 { get; set; }
            public string NashikRoad5 { get; set; }
            public string Upnagar6 { get; set; }
            public string ShubhamPark7 { get; set; }
            public string AshwinNagar8 { get; set; }
            public string IndiraNagar9 { get; set; }
            public string DevlaliCamp10 { get; set; }
    }
}
