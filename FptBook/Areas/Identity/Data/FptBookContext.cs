using FptBook.Areas.Identity.Data;
using FptBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FptBook.Data;

public class FptBookContext : IdentityDbContext<FptBookUser>
{
    public FptBookContext(DbContextOptions<FptBookContext> options)
        : base(options)
    {
    }
    public DbSet<Store> Store { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
    public DbSet<Cart> Cart { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<FptBookUser>()
           .HasOne<Store>(au => au.Store)
           .WithOne(st => st.User)
           .HasForeignKey<Store>(st => st.UId)
           ;
        builder.Entity<Book>()
            .HasOne<Store>(b => b.Store)
            .WithMany(st => st.Books)
            .HasForeignKey(b => b.StoreId) //ket noi 1 nhieu 
            ;
        builder.Entity<Order>()
            .HasOne<FptBookUser>(od => od.User)
            .WithMany(ap => ap.Orders)
            .HasForeignKey(od => od.UId)
            ;
        builder.Entity<OrderDetail>()

            .HasKey(od => new { od.OrderId, od.BookIsbn });

        builder.Entity<OrderDetail>()
            .HasOne<Order>(od => od.Order)
            .WithMany(or => or.OrderDetails)
            .HasForeignKey(od => od.OrderId);

        builder.Entity<OrderDetail>()
            .HasOne<Book>(od => od.Book)
            .WithMany(b => b.OrderDetails)
            .HasForeignKey(od => od.BookIsbn);

        builder.Entity<Cart>()
           .HasKey(c => new { c.UId, c.BookIsbn });

        builder.Entity<Cart>()
            .HasOne<FptBookUser>(c => c.User)
            .WithMany(ap => ap.Carts)
            .HasForeignKey(c => c.UId);

        builder.Entity<Cart>()
            .HasOne<Book>(c => c.Book)
            .WithMany(b => b.Carts)
            .HasForeignKey(c => c.BookIsbn)
            .OnDelete(DeleteBehavior.NoAction);

    
    }
}
