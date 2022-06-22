namespace ProjectAPi.Models
{
    public class ProjectResponse
    {
        public Int32 Id { get; set; }
        public Int32 Total { get; set; }

        public String? Name { get; set; }
        public String? ProjectLeader { get; set; }

        public String? Description { get; set; }
        public string? Customer { get; internal set; }
    }
}
