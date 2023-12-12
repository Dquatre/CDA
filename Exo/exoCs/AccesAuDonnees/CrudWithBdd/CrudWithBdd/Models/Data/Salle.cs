using System;
using System.Collections.Generic;

namespace CrudWithBdd.Models.Data;

public partial class Salle
{
    public int IdSalle { get; set; }

    public string CodeSalle { get; set; } = null!;

    public int Surface { get; set; }

    public int NombrePlace { get; set; }

    public int IdBatimentSalle { get; set; }

    public virtual Salle IdBatimentNavigation { get; set; } = null!;
}
