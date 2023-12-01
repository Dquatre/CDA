using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudPersistant.Models.Dtos
{
    public class ProductDtoOut
    {
        public string NameProduct { get; set; } = null!;

        public double Price { get; set; }

        public int Quantity { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
