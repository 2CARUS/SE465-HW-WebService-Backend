using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Models
{
    [Table("minneapolisitems")]
    public class MinneapolisItem
    {
        #region "Table Attributes"
        [Column("mplsitemid")]
        public int Id { get; set; }

        [Column("quantity")]
        public string Quantity { get; set; }

        [Column("itemname")]
        public string ItemName { get; set; }

        #endregion


    }
}
