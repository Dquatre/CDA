using System;
using System.Collections.Generic;

namespace GestionStock.Models.Data;

public partial class Category
{
    public int IdCategorie { get; set; }

    public string LibelleCategorie { get; set; } = null!;

    public int IdTypeProduit { get; set; }

    public virtual ICollection<Article> ListArticles { get; set; } = new List<Article>();

    public virtual Typesproduit TheTypesproduit { get; set; } = null!;
}
