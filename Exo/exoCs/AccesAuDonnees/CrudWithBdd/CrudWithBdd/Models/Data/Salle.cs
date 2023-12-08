using System;
using System.Collections.Generic;

namespace CrudWithBdd.Models.Data;

public partial class Salle
{
    public int IdSalle { get; set; }

    public string CodeSalle { get; set; } = null!;

    public int Surface { get; set; }

    public int NombrePlace { get; set; }

    public int IdBatiment { get; set; }

    public virtual Batiment IdBatimentNavigation { get; set; } = null!;
}
