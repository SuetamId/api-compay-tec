namespace controller_api_v1.Models.Entity
{
    public class Collaborator
    {
        public int Id { get; set; }

        public string? nickName { get; set; }

        public string? document { get; set; }
      
        public DateTime? created_at { get; set; }
    }
}
