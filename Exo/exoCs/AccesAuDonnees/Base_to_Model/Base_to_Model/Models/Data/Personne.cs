using System;
using System.Collections.Generic;

namespace Base_to_Model.Models.Data;

public partial class Personne
{
    public int IdPersonne { get; set; }

    public string Prenom { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public int Age { get; set; }
}
