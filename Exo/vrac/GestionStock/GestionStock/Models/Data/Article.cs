using System;
using System.Collections.Generic;

namespace GestionStock.Models.Data;

public partial class Article
{
    public int IdArticle { get; set; }

    public string LibelleArticle { get; set; } = null!;

    public int QuantiteStockee { get; set; }

    public int IdCategorie { get; set; }

    public virtual Category TheCategory { get; set; } = null!;
}
