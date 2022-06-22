using Microsoft.EntityFrameworkCore;
using ProjectAPi.Models;
using System.Diagnostics.CodeAnalysis;

namespace ProjectAPi.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Project { get; set; } = null!;

        public DbSet<Hours> Hours { get; set; }

        public DbSet<Users> Users { get; set; }
    }
}
