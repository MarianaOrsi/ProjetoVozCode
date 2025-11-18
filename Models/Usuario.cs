using System;
using System.Collections.Generic;

namespace ProjetoVozCode.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual ICollection<Arquivo> Arquivos { get; set; } = new List<Arquivo>();
}
