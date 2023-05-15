using System.Collections.Generic;

namespace OntimeBackEnd.Models
{
    public class GetData
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<StudentModelRequest> StudentModelRequest { get; set; }
    }
    public class GetDataById
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public StudentModelRequest StudentModelRequest { get; set; }
    }
}
