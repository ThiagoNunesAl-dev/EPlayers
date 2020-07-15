using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPlayers.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

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

            //Upload de imagem.
            var file = form.Files[0];
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

            if (file != null) {
                if (!Directory.Exists(folder)) {
                    Directory.CreateDirectory(folder);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create)) {
                    file.CopyTo(stream);
                }
                equipe.Imagem = file.FileName;
            }
            else {
                equipe.Imagem = "padrao.png";
            }
            //Fim da parte de upload de imagem.

            equipeModel.Criar(equipe);

            return LocalRedirect("~/Equipe");
        }

        [Route("[controller]/{id}")]
        public IActionResult Excluir (int id) {
            equipeModel.Deletar(id);
            return LocalRedirect("~/Equipe");
        }
    }
}