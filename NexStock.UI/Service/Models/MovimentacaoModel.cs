using System;
using System.Collections.Generic;
using System.Text;

namespace NexStock.UI.Service.Models;

public class MovimentacaoDto
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public string Responsavel { get; set; } = string.Empty;
    public string? NotaFiscal { get; set; }
    public DateTime Data { get; set; }
    public int ProdutoId { get; set; }
    public int UsuarioId { get; set; }
}
public class CriarMovimentacaoDto
{
    public string Tipo { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public string Responsavel { get; set; } = string.Empty;
    public string? NotaFiscal { get; set; }
    public int ProdutoId { get; set; }
    public int UsuarioId { get; set; }
}
public class AtualizarMovimentacaoDto
{
    public string Tipo { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public string Responsavel { get; set; } = string.Empty;
    public string? NotaFiscal { get; set; }
    public int ProdutoId { get; set; }
    public int UsuarioId { get; set; }
}
