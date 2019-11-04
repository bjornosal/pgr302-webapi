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

        //TODO: Make concurrent https://stackoverflow.com/questions/15669383/how-to-inc-dec-multi-user-safe-in-entity-framework-5/15669840#15669840
        //[ConcurrencyCheck]
        public int Stock { get; set; }

    }
}