using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula_6_LP3_Parte2.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
    }
}