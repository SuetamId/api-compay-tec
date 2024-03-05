using controller_api_v1.Models.Entities;
using controller_api_v1.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace controller_api_v1.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) :
            base(options)
        { }

        public DbSet<Collaborator>? Collaborators => Set<Collaborator>();
        public DbSet<Tag>? Tags => Set<Tag>();

    }
}
