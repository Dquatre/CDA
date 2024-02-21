using System;
using System.Collections.Generic;

namespace CrudWithBdd.Models.Data;

public partial class Salle
{
    public int IdBatiment { get; set; }

    public string NomBatiment { get; set; } = null!;

    public virtual ICollection<Salle> Salles { get; set; } = new List<Salle>();
}
