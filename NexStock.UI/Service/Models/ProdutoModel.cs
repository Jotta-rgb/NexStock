using System;
using System.Collections.Generic;
using System.Text;

namespace NexStock.UI.Service.Models;

public class ProdutoDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Unidade { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public int EstoqueMinimo { get; set; }
    public int CategoriaId { get; set; }
    public int LocalizacaoId { get; set; }
}

public class CriarProdutoDto
{
    public string Nome { get; set; } = string.Empty;
    public string Unidade { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public int EstoqueMinimo { get; set; }
    public int CategoriaId { get; set; }
    public int LocalizacaoId { get; set; }
}

public class AtualizarProdutoDto
{
    public string Nome { get; set; } = string.Empty;
    public string Unidade { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public int EstoqueMinimo { get; set; }
    public int CategoriaId { get; set; }
    public int LocalizacaoId { get; set; }
}
