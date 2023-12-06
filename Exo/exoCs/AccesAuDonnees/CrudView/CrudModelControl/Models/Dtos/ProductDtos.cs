namespace CrudModelControl.Models.Dtos
{
    public class ProductDtoOut
    {
        public string NameProduct { get; set; } = null!;

        public double Price { get; set; }

        public int Quantity { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
    public class ProductDtoFull
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; } = null!;

        public double Price { get; set; }

        public int Quantity { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
