using System;
using System.Collections.Generic;

namespace ProjetoVozCode.Models;

public partial class Execusao
{
    public int Id { get; set; }

    public string? SaidaTerminal { get; set; }

    public string? ErroTerminal { get; set; }

    public int? ArquivoId { get; set; }

    public virtual Arquivo? Arquivo { get; set; }
}
