using System.Collections.Generic;
using System.Threading.Tasks;
using APITW.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventoInterface
{
    public interface EventoInterface
    {
        Task<List<Evento>> Listar();

         Task<Evento> Put(int id, Evento evento);

         Task<Evento> Delete(int id);
         
    }
}
