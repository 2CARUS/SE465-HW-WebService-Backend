using Microsoft.EntityFrameworkCore;
using InventoryApi.Models;

namespace InventoryApi.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<MinneapolisItem> MinneapolisItems { get; set; }
    }
}