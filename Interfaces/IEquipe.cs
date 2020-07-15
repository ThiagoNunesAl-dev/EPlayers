using System.Collections.Generic;
using EPlayers.Models;

namespace EPlayers.Interfaces
{
    public interface IEquipe
    {
         void Criar (Equipe e);
         List<Equipe> Ler ();
         void Alterar (Equipe e);
         void Deletar (int IdEquipe);
    }
}