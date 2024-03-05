using System.ComponentModel.DataAnnotations;

namespace controller_api_v1.Models.Entities
{
    public class Tag
    {
        public int id { get; set; }
        public string? description { get; set; }
        public bool? isActive { get; set; }   
        public DateTime? created_at { get; set; }

    }
}
