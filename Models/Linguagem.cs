using System;
using System.Collections.Generic;

namespace ProjetoVozCode.Models;

public partial class Linguagem
{
    public int Id { get; set; }

    public string? Linguagem1 { get; set; }

    public virtual ICollection<Arquivo> Arquivos { get; set; } = new List<Arquivo>();
}
