using System.Collections.Generic;
using DevReviews.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevReviews.API.Persistence
{
    public class DevReviewsDbContext : DbContext
    {
        public DevReviewsDbContext(DbContextOptions<DevReviewsDbContext> options) : base(options)
        {
            // Products = new List<Product>();  criar a lista para não retornar nulo            
        }
        public DbSet<Product> Products{ get; set; }
        public DbSet<ProductReview> ProductReviews{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            // vamos configurar aqui as chaves primárias para as tabelas
            // modelBuilder.Entity<Product>()
            //     .ToTable("tb_Product");

            // modelBuilder.Entity<Product>()
            //     .HasKey(p => p.Id);
            
            // modelBuilder.Entity<ProductReview>()
            //     .ToTable("tb_ProductReviews");

            modelBuilder.Entity<Product>(p => {
                p.ToTable("tb_Product");
                p.HasKey(p => p.Id);

                p
                .HasMany(pp => pp.Reviews)
                //.WithOne(r => r.Product)
                .WithOne()
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Restrict);//o que acontece com o product review quando deletar um produto;
                // Com .Cascade, todas as entidades relacionadas são apagadas
            });

            modelBuilder.Entity<ProductReview>(pr => {
                pr.ToTable("tb_ProductReviews");
                pr.HasKey(p => p.Id);
                pr.Property(p => p.Author).HasMaxLength(50).IsRequired();
                //.HasColumnName("author");
            });
        }

    }
}