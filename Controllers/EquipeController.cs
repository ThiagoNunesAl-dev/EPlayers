using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPlayers.Models;
using Microsoft.AspNetCore.Http;

namespace EPlayers.Controllers
{
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();

        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.Ler();
            return View();
        }

        public IActionResult Cadastrar (IFormCollection form) {
            Equipe equipe = new Equipe();
            equipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            equipe.Nome = form["Nome"];
            equipe.Imagem = form["Imagem"];

            equipeModel.Criar(equipe);

            ViewBag.Equipes = equipeModel.Ler();
            return LocalRedirect("~/Equipe");
        }
    }
}