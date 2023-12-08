using System;
using System.Collections.Generic;

namespace WpfCrud01.Models.Data;

public partial class Livre
{
    public int IdLivre { get; set; }

    public string TitreLivre { get; set; } = null!;

    public int NombrePage { get; set; }

    public string Auteur { get; set; } = null!;
    
    public string Editeur { get; set; } = null!;
}
