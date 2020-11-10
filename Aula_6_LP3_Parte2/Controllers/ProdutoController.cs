using Aula_6_LP3_Parte2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_6_LP3_Parte2.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Produtos()
        {
            List<Produto> ListaProduto = new List<Produto>();
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
                    ListaProduto.Add(produto);
                }
                Conexao.Fechaconexao();
            }
            return View(ListaProduto);
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            if (Conexao.Conecta())
            {
                Conexao.Executacomando("insert into Produto values(" + produto.IdProduto + ",'" + produto.NomeProduto + "','" + produto.Descricao + "'," + produto.Preco + ")");
                Conexao.Fechaconexao();
            }
            return View(produto);
        }

        public ActionResult DeletarProduto(int Id)
        {
            if (Conexao.Conecta())
            {
                Conexao.Executacomando("Delete from Produto where Id = " + Id + "");
                Conexao.Fechaconexao();
            }
            return View();
        }

        public ActionResult AtualizarProduto(int Id)
        {
            Produto produto = new Produto();
            if (Conexao.Conecta())
            {
                Conexao.Executacomando("select * from Produto where IdProduto = " + Id + "");
                produto.IdProduto = Convert.ToInt32(Conexao.leitor["IdProduto"]);
                produto.NomeProduto = Conexao.leitor["NomeProduto"].ToString();
                produto.Preco = Convert.ToDouble(Conexao.leitor["Preco"]);
                produto.Descricao = Conexao.leitor["Descricao"].ToString();

                Conexao.Fechaconexao();
            }
            return View(produto);
        }

        public ActionResult AtualizarProduto(Produto produto)
        {
            if (Conexao.Conecta())
            {
                Conexao.Executacomando("update Produto set Nome = '" + produto.NomeProduto + "', Descricao = '" + produto.Descricao + "', Preco = " + produto.Preco + " where Id = " + produto.IdProduto + "");
                Conexao.Fechaconexao();
            }
            return RedirectToAction("Produtos");
        }
    }
}