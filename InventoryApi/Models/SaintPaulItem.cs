using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Models
{
    [Table("saintpaulitems")]
    public class SaintPaulItem
    {
        #region "Table Attributes"
        [Column("stplitemid")]
        public int Id { get; set; }

        [Column("quantity")]
        public long Quantity { get; set; }

        [Column("itemname")]
        public string ItemName { get; set; }

        #endregion


    }
}
