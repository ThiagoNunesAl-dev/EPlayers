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
    public class NoticiasController : Controller
    {
        Noticias noticiaModel = new Noticias();

        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.Ler();
            return View();
        }

        public IActionResult Cadastrar (IFormCollection form) {
            Noticias noticia = new Noticias();
            noticia.IdNoticia = Int32.Parse(form["IdNoticia"]);
            noticia.Titulo = form["Titulo"];
            noticia.Texto = form["Texto"];

            //Upload de imagem.
            var file = form.Files[0];
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if (file != null) {
                if (!Directory.Exists(folder)) {
                    Directory.CreateDirectory(folder);
                }
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create)) {
                    file.CopyTo(stream);
                }
                noticia.Imagem = file.FileName;
            }
            else {
                noticia.Imagem = "padrao.png";
            }
            //Fim da parte de upload de imagem.

            noticiaModel.Criar(noticia);

            return LocalRedirect("~/Noticias");
        }
        
        [Route("[controller]/{id}")]
        public IActionResult Excluir (int id) {
            noticiaModel.Deletar(id);
            return LocalRedirect("~/Noticias");
        }
    }
}