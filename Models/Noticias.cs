using System;
using System.Collections.Generic;
using System.IO;
using EPlayers.Interfaces;

namespace EPlayers.Models
{
    public class Noticias : EplayersBase, INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string Path = "Database/Noticias.csv";

        /// <summary>
        /// Cria uma pasta e um arquivo CSV para as notícias, caso não exista.
        /// </summary>
        public Noticias () {
            CriarArquivoEPasta(Path);
        }

        /// <summary>
        /// Prepara uma linha no formato CSV.
        /// </summary>
        /// <param name="n">Notícia selecionada.</param>
        /// <returns>Linha no formato CSV.</returns>
        public string PrepararLinha (Noticias n) {
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        /// <summary>
        /// Substitui uma notícia por outra no arquivo CSV.
        /// </summary>
        /// <param name="n">Nova notícia adicionada.</param>
        public void Alterar(Noticias n)
        {
            List<string> linhas = LerCSV(Path);
            linhas.RemoveAll(y => y.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add(PrepararLinha(n));
            ReescreverCSV(Path, linhas);           
        }

        /// <summary>
        /// Adiciona as informações da notícia escrita ao CSV.
        /// </summary>
        /// <param name="n">Equipe escrita.</param>
        public void Criar(Noticias n)
        {
            string[] linha = {PrepararLinha(n)};
            File.AppendAllLines(Path, linha);
        }

        /// <summary>
        /// Deleta uma notícia do arquivo CSV, de acordo com seu Identificador.
        /// </summary>
        /// <param name="IdNoticia">Identificador.</param>
        public void Deletar(int IdNoticia)
        {
            List<string> linhas = LerCSV(Path);
            linhas.RemoveAll(y => y.Split(";")[0] == IdNoticia.ToString());
            ReescreverCSV(Path, linhas);
        }

        /// <summary>
        /// Lê o arquivo CSV.
        /// </summary>
        /// <returns>Informações das notícias colocadas no arquivo CSV.</returns>
        public List<Noticias> Ler()
        {
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(Path);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];
                noticias.Add(noticia);
            }
            return noticias;
        }
    }
}