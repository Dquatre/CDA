using System;
using System.Collections.Generic;

namespace CrudModelControl.Models.Data;

public partial class Product
{
    public int IdProduct { get; set; }

    public string NameProduct { get; set; } = null!;

    public double Price { get; set; }

    public int Quantity { get; set; }

    public DateTime? ReleaseDate { get; set; }
}
