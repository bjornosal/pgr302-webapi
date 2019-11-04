using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WarehouseApi.Models
{
    public class Item
    {

        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [ConcurrencyCheck]
        public int Stock { get; set; }

    }
}