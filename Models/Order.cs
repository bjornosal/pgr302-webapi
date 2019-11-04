using System.ComponentModel.DataAnnotations;

namespace WarehouseApi.Models
{
    public class Order
    {

        [Key]
        public int Id { get; set; }

        public Item[] items { get; set; }
    }
}