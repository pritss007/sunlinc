using System.ComponentModel.DataAnnotations;

namespace OntimeBackEnd.Models
{
    public class DeleteData
    {
        [Required]
        public string Id { get; set; }
    }
    public class DeleteResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
