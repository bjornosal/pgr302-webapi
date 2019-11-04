using System.ComponentModel.DataAnnotations;

namespace WarehouseApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public Order[] Orders { get; set; }

    }
}