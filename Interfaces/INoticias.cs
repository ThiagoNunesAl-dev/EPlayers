using System.Collections.Generic;
using EPlayers.Models;

namespace EPlayers.Interfaces
{
    public interface INoticias
    {
         void Criar (Noticias n);
         List<Noticias> Ler (); 
         void Alterar (Noticias n);
         void Deletar (int IdNoticia);
    }
}