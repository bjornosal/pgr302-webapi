using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WarehouseApi.Models
{
    public class Location
    {

        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public int MaxItems { get; set; }

        public List<Item> Items { get; set; }

    }
}