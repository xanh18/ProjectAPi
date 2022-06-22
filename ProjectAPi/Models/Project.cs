using System.Text.Json.Serialization;

namespace ProjectAPi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ProjectLeader { get; set; }
        public string? Customer { get; set; }

        public ICollection<Hours> Hours { get; set; }
    }
}
