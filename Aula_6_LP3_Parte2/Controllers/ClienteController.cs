using Aula_6_LP3_Parte2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_6_LP3_Parte2.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Clientes()
        {
            List<Cliente> ListaCliente = new List<Cliente>();
            if (Conexao.Conecta())
            {
                Conexao.Executacomando("select * from Cliente");
                while (Conexao.leitor.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = Convert.ToInt32(Conexao.leitor["Id"]);
                    cliente.Nome = Conexao.leitor["Nome"].ToString();
                    cliente.Sexo = Conexao.leitor["Sexo"].ToString();
                    cliente.Endereco = Conexao.leitor["Endereco"].ToString();
                    ListaCliente.Add(cliente);
                }
                Conexao.Fechaconexao();
            }
            return View(ListaCliente);
        }

        public ActionResult CadastrarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCliente(Cliente cliente)
        {
            if (Conexao.Conecta())
            {
                Conexao.Executacomando("insert into Cliente values(" + cliente.IdCliente + ",'" + cliente.Nome + "','" + cliente.Sexo + "','" + cliente.Endereco + "')");
                Conexao.Fechaconexao();
            }
            return RedirectToAction("Clientes");
        }

        public ActionResult DeletarCliente(int Id)
        {
            if (Conexao.Conecta())
            {
                Conexao.Executacomando("Delete from Cliente where Id = " + Id + "");
                Conexao.Fechaconexao();
            }
            return RedirectToAction("Clientes");
        }

        public ActionResult AtualizarCliente(int Id)
        {
            Cliente cliente = new Cliente();
            if (Conexao.Conecta())
            {
                Conexao.Executacomando("select * from Cliente where Id = " + Id + "");
                if (Conexao.leitor.Read())
                {
                    cliente.IdCliente = Convert.ToInt32(Conexao.leitor["Id"]);
                    cliente.Nome = Conexao.leitor["Nome"].ToString();
                    cliente.Endereco = Conexao.leitor["Endereco"].ToString();
                    cliente.Sexo = Conexao.leitor["Sexo"].ToString();
                }
                Conexao.Fechaconexao();
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult AtualizarCliente(Cliente cliente)
        {
            if (Conexao.Conecta())
            {
                Conexao.Executacomando("update Cliente set Nome = '" + cliente.Nome + "', Sexo = '" + cliente.Sexo + "', Endereco = '" + cliente.Endereco + "' where Id = " + cliente.IdCliente + "");
                Conexao.Fechaconexao();
            }
            return RedirectToAction("Clientes");
        }
    }
}