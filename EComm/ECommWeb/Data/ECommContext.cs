using Microsoft.EntityFrameworkCore;

namespace ECommWeb.Data;

public class ECommContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
}
