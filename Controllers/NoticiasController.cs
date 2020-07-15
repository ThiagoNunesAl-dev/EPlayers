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
            noticia.IdNoticia = Int32.Parse(form["IdNotícia"]);
            noticia.Titulo = form["Título"];
            noticia.Texto = form["Texto"];
            noticia.Imagem = form["Imagem"];

            noticiaModel.Criar(noticia);

            ViewBag.Noticias = noticiaModel.Ler();
            return LocalRedirect("~/Notícias");
        }
    }
}