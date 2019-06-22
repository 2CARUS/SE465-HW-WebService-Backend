using Microsoft.EntityFrameworkCore;
using InventoryApi.Models;

namespace InventoryApi.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }


        #region "Database Sets"

        public DbSet<MinneapolisItem> MinneapolisItems { get; set; }

        public DbSet<SaintPaulItem> SaintPaulItems { get; set; }


        #endregion
    }
}