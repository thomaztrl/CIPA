using Microsoft.AspNetCore.Mvc;
using CIPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CIPA.Controllers
{
    public class CandidatoController : Controller
    {
        // Lista estática para armazenar os candidatos (substitua por um banco de dados em um cenário real)
        private static List<Candidato> candidatos = new List<Candidato>();

        // GET: Candidato
        public IActionResult Index()
        {
            return View(candidatos);
        }

        // GET: Candidato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidato/Create
        [HttpPost]
        public IActionResult Create(Candidato candidato)
        {
            // Validação do número do partido
            if (candidato.NumeroPartido.ToString().Length != 4)
            {
                ModelState.AddModelError("NumeroPartido", "O número do partido deve ter exatamente 4 dígitos.");
            }

            // Verifica se o modelo é válido
            if (ModelState.IsValid)
            {
                // Gera um ID para o candidato
                candidato.Id = candidatos.Count + 1;
                // Adiciona o candidato à lista
                candidatos.Add(candidato);
                // Redireciona para a lista de candidatos
                return RedirectToAction("Index");
            }

            // Se houver erros de validação, retorna para a view de criação
            return View(candidato);
        }

        // GET: Candidato/Edit/5
        public IActionResult Edit(int id)
        {
            // Busca o candidato pelo ID
            var candidato = candidatos.FirstOrDefault(c => c.Id == id);
            if (candidato == null)
            {
                return NotFound(); // Retorna um erro 404 se o candidato não for encontrado
            }
            return View(candidato);
        }

        // POST: Candidato/Edit/5
        [HttpPost]
        public IActionResult Edit(Candidato candidato)
        {
            // Validação do número do partido
            if (candidato.NumeroPartido.ToString().Length != 4)
            {
                ModelState.AddModelError("NumeroPartido", "O número do partido deve ter exatamente 4 dígitos.");
            }

            // Verifica se o modelo é válido
            if (ModelState.IsValid)
            {
                // Busca o candidato existente pelo ID
                var existingCandidato = candidatos.FirstOrDefault(c => c.Id == candidato.Id);
                if (existingCandidato != null)
                {
                    // Atualiza os dados do candidato
                    existingCandidato.Nome = candidato.Nome;
                    existingCandidato.NumeroPartido = candidato.NumeroPartido;
                }
                // Redireciona para a lista de candidatos
                return RedirectToAction("Index");
            }

            // Se houver erros de validação, retorna para a view de edição
            return View(candidato);
        }

        // GET: Candidato/Details/5
        public IActionResult Details(int id)
        {
            // Busca o candidato pelo ID
            var candidato = candidatos.FirstOrDefault(c => c.Id == id);
            if (candidato == null)
            {
                return NotFound(); // Retorna um erro 404 se o candidato não for encontrado
            }
            return View(candidato);
        }

        // GET: Candidato/Delete/5
        public IActionResult Delete(int id)
        {
            // Busca o candidato pelo ID
            var candidato = candidatos.FirstOrDefault(c => c.Id == id);
            if (candidato == null)
            {
                return NotFound(); // Retorna um erro 404 se o candidato não for encontrado
            }
            return View(candidato);
        }

        // POST: Candidato/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Busca o candidato pelo ID
            var candidato = candidatos.FirstOrDefault(c => c.Id == id);
            if (candidato != null)
            {
                // Remove o candidato da lista
                candidatos.Remove(candidato);
            }
            // Redireciona para a lista de candidatos
            return RedirectToAction("Index");
        }

        // GET: Candidato/Pesquisar
        public IActionResult Pesquisar()
        {
            return View();
        }

        // POST: Candidato/Pesquisar
        [HttpPost]
        public IActionResult Pesquisar(string termoPesquisa)
        {
            // Verifica se o termo de pesquisa foi fornecido
            if (string.IsNullOrEmpty(termoPesquisa))
            {
                ViewBag.Mensagem = "Por favor, insira um termo de pesquisa.";
                return View(new List<Candidato>());
            }

            // Realiza a pesquisa no nome e no número do partido
            var resultados = candidatos
                .Where(c => c.Nome.Contains(termoPesquisa, StringComparison.OrdinalIgnoreCase) ||
                            c.NumeroPartido.ToString().Contains(termoPesquisa))
                .ToList();

            // Exibe os resultados na view
            return View(resultados);
        }
    }
}