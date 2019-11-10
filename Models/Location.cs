using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WarehouseApi.Models
{
    public class Location
    {

        [Key]
        public long Id { get; set; }

        public string Name { get; set; }


    }
}