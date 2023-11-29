using System;
using System.Collections.Generic;

namespace ApiMinetesme.Data.Models;

public partial class Pantalon
{
    public int Id { get; set; }

    public string Marque { get; set; } = null!;

    public string Couleur { get; set; } = null!;

    public int Taille { get; set; }
}
