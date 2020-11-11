using Aula_6_LP3_Parte2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_6_LP3_Parte2.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Compras()
        {
            Compra compra = new Compra();
            compra.Produtos = new List<Produto>();
            if (TempData["Compra"] == null)
            {
                if (Conexao.Conecta())
                {
                    Conexao.Executacomando("select * from Produto");
                    while (Conexao.leitor.Read())
                    {
                        Produto produto = new Produto();
                        produto.IdProduto = Convert.ToInt32(Conexao.leitor["Id"]);
                        produto.NomeProduto = Conexao.leitor["Nome"].ToString();
                        produto.Descricao = Conexao.leitor["Descricao"].ToString();
                        produto.Preco = Convert.ToDouble(Conexao.leitor["Preco"]);
                        compra.Produtos.Add(produto);
                    }
                    Conexao.Fechaconexao();
                }
                TempData["Compra"] = compra;
            }
            else
            {
                compra = TempData["Compra"] as Compra;
                TempData.Keep("Compra");
            }
            return View(compra);
        }

        [HttpPost]
        public ActionResult AdicionarCompra(List<int> qtd)
        {
            Compra compra = new Compra();
            compra = TempData["Compra"] as Compra;
            double val = 0;
            for (int i = 0; i < qtd.Count; i++)
            {
                compra.Produtos[i].QTD = qtd[i];
                val += compra.Produtos[i].Preco * compra.Produtos[i].QTD;
            }
            compra.ValorTotal = val;
            TempData["Compra"] = compra;
            return RedirectToAction("Compras");
        }
    }
}