// Controllers/VotacaoController.cs
using Microsoft.AspNetCore.Mvc;
using CIPA.Models;

namespace CIPA.Controllers
{
    public class VotacaoController : Controller
    {
        public IActionResult RegistrarVoto()
        {
            return View(DataStore.Candidatos);
        }

        [HttpPost]
        public IActionResult RegistrarVoto(int candidatoId)
        {
            var candidato = DataStore.Candidatos.FirstOrDefault(c => c.Id == candidatoId);
            if (candidato != null)
            {
                candidato.Votos++;
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult MostrarResultado()
        {
            return View(DataStore.Candidatos);
        }
    }
}