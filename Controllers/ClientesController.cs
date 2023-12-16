using Cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Cadastro.Models;
using System;
using System.Collections.Generic;

namespace SuaAplicacao.Controllers
{
    public class ClientesController : Controller
    {
        private static List<Cliente> listaDeClientes = new List<Cliente>();

        public IActionResult Index()
        {
            return View(listaDeClientes);
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Id = listaDeClientes.Count + 1;
                listaDeClientes.Add(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }



        public IActionResult Editar(int id)
        {
            var cliente = listaDeClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound(); // Retorna um erro 404 se o cliente não for encontrado
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteExistente = listaDeClientes.FirstOrDefault(c => c.Id == cliente.Id);

                if (clienteExistente == null)
                {
                    return NotFound(); // Retorna um erro 404 se o cliente não for encontrado
                }

                // Atualiza os dados do cliente existente com os novos dados
                clienteExistente.NomeCompleto = cliente.NomeCompleto;
                clienteExistente.Email = cliente.Email;
                clienteExistente.CPF = cliente.CPF;
                clienteExistente.DataNascimento = cliente.DataNascimento;

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public IActionResult Excluir(int id)
        {
            var cliente = listaDeClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound(); // Retorna um erro 404 se o cliente não for encontrado
            }

            listaDeClientes.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}