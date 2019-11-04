using System.ComponentModel.DataAnnotations;

namespace WarehouseApi.Models
{
    public class Item
    {

        [Key]
        public int Id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public int stock { get; set; }
    }
}