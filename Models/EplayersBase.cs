using System.Collections.Generic;
using System.IO;

namespace EPlayers.Models
{
    public class EplayersBase
    {
        /// <summary>
        /// Cria uma pasta e um arquivo, caso não existam (de acordo com o caminho indicado).
        /// </summary>
        /// <param name="_path">Caminho indicado.</param>
        public void CriarArquivoEPasta (string _path) {
            string pasta = _path.Split ("/")[0];
            
            if (!Directory.Exists(pasta)) {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_path)) {
                File.Create(_path).Close();
            }
        }

        /// <summary>
        /// Método base que lê todas as linhas de um arquivo CSV.
        /// </summary>
        /// <param name="_path">Caminho para a pasta do arquivo CSV.</param>
        /// <returns>As linhas do arquivo escolhido.</returns>
        public List<string> LerCSV (string _path) {
            List<string> linhas = new List<string>();
            using(StreamReader file = new StreamReader(_path))
            {
                string linha;
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }

        /// <summary>
        /// Reescreve um arquivo CSV.
        /// </summary>
        /// <param name="_path">Caminho para a pasta do arquivo CSV.</param>
        /// <param name="linhas">Lista de linhas do arquivo.</param>
        public void ReescreverCSV (string _path, List<string> linhas) {
            using(StreamWriter output = new StreamWriter(_path))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}