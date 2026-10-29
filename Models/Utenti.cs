using System;
using System.Collections.Generic;

namespace Contacter.Models;

public partial class Utenti
{
    public long UteId { get; set; }

    public string UteEmail { get; set; } = null!;

    public string UtePass { get; set; } = null!;

    public virtual ICollection<Contatti> Contattis { get; set; } = new List<Contatti>();
}
