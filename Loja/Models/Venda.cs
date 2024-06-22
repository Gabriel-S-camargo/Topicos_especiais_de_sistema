using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Models
{
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public int NumNotaFiscal { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; } // Singular
        public double ValorVenda { get; set; }
    }
}
