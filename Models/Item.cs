using System.ComponentModel.DataAnnotations;

namespace WarehouseApi.Models
{
    public class Item
    {

        [Key]
        public int Id { get; set; }

        public string name { get; set; }
    }
}