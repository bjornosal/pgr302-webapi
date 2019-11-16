using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int Stock { get; set; }
        public long? LocationId { get; set; }
        public Location Location { get; set; }
    }
}