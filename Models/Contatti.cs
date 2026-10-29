using System;
using System.Collections.Generic;

namespace Contacter.Models;

public partial class Contatti
{
    public long ConId { get; set; }

    public string ConNome { get; set; } = null!;

    public string? ConEmail { get; set; }

    public string? ConTel { get; set; }

    public long ConUteId { get; set; }

    public virtual Utenti ConUte { get; set; } = null!;
}
