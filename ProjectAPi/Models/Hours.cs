using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPi.Models
{
    public class Hours
    {
        public int Id { get; set; }
        
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }

        public string? Name { get; set; }

        public int? FrontEnd { get; set; }

        public int? BackEnd { get; set; }

        public bool? IsActive { get; set; }

        public Project? Project { get; set; }

    }
}
