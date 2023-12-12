using System;
using System.Collections.Generic;

namespace GestionStock.Models.Data;

public partial class Typesproduit
{
    public int IdTypeProduit { get; set; }

    public string LibelleTypeProduit { get; set; } = null!;

    public virtual ICollection<Category> ListCategories { get; set; } = new List<Category>();
}
