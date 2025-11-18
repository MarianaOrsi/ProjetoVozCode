using System;
using System.Collections.Generic;

namespace ProjetoVozCode.Models;

public partial class Arquivo
{
    public int Id { get; set; }

    public string? NomeArquivo { get; set; }

    public DateTime? DataModificacao { get; set; }

    public int? LinguagemId { get; set; }

    public int? UsuarioId { get; set; }

    public virtual ICollection<Execusao> Execusaos { get; set; } = new List<Execusao>();

    public virtual Linguagem? Linguagem { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
