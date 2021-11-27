using Microsoft.EntityFrameworkCore;
using TodoListGraphQL.Api.Models;

namespace TodoListGraphQL.Api.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<Item> Items {get;set;}
        public virtual DbSet<ItemList> Lists {get;set;}

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasOne(d => d.ItemList)
                    .WithMany(p => p.ItemDatas)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ItemData_ItemList");
            });
        }
    }
}