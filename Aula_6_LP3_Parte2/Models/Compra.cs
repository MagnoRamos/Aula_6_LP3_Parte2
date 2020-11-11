using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula_6_LP3_Parte2.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<Produto> ProdutosSelecionados { get; set; }
        public double ValorTotal { get; set; }
    }
}