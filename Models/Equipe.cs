using System;
using System.Collections.Generic;
using System.IO;
using EPlayers.Interfaces;

namespace EPlayers.Models
{
    public class Equipe : EplayersBase, IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string Path = "Database/Equipe.csv";

        /// <summary>
        /// Cria uma pasta e um arquivo CSV para as equipes, caso não exista.
        /// </summary>
        public Equipe () {
            CriarArquivoEPasta(Path);
        }

        /// <summary>
        /// Prepara uma linha no formato CSV.
        /// </summary>
        /// <param name="e">Equipe selecionada.</param>
        /// <returns>Uma linha no formato CSV.</returns>
        public string PrepararLinha (Equipe e) {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        /// <summary>
        /// Substitui uma equipe por outra no arquivo CSV.
        /// </summary>
        /// <param name="e">Nova equipe adicionada.</param>
        public void Alterar(Equipe e)
        {
            List<string> linhas = LerCSV(Path);
            linhas.RemoveAll(y => y.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(PrepararLinha(e));
            ReescreverCSV(Path, linhas);
        }

        /// <summary>
        /// Adiciona as informações da equipe criada ao CSV.
        /// </summary>
        /// <param name="e">Equipe criada.</param>
        public void Criar(Equipe e)
        {
            string[] linha = {PrepararLinha(e)};
            File.AppendAllLines(Path, linha);
        }

        /// <summary>
        /// Deleta uma equipe do arquivo CSV, de acordo com seu Identificador.
        /// </summary>
        /// <param name="IdEquipe">Identificador.</param>
        public void Deletar(int IdEquipe)
        {
            List<string> linhas = LerCSV(Path);
            linhas.RemoveAll(y => y.Split(";")[0] == IdEquipe.ToString());
            ReescreverCSV(Path, linhas);
        }

        /// <summary>
        /// Lê o arquivo CSV.
        /// </summary>
        /// <returns>Informações das equipes colocadas no arquivo CSV.</returns>
        public List<Equipe> Ler()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(Path);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];
                equipes.Add(equipe);
            }
            return equipes;
        }
    }
}