using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APITW.Models;
using APITW.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back_TW.Repositorio
{
    public class EventoRepositorio
    {
             ComunidadeRepositorio ComunidadeRepositorio  = new ComunidadeRepositorio();
       AgendaThoughtWorksContext context = new   AgendaThoughtWorksContext();


        public async Task<ActionResult<List<Evento>>> Listar()
        {
            List<Evento> listaDeEventos = await context.Evento.Include(a => a.IdAdministrador)                
            .Include(c => c.NomeComunidade)
            .ToListAsync();
                
           
            return listaDeEventos;
        }

        public async Task<ActionResult<Evento>> Put(int id, Evento Evento)
        {
            Evento eventoAtualizado = await context.Evento.FindAsync(id);
           
            eventoAtualizado.NomeEvento = Evento.NomeEvento;
            eventoAtualizado.IdCategoria = Evento.IdCategoria;
            eventoAtualizado.Descricao = Evento.Descricao;
            eventoAtualizado.DataEvento = Evento.DataEvento;
            eventoAtualizado.HoraEvento = Evento.HoraEvento;
            eventoAtualizado.Localizacao = Evento.Localizacao;
            eventoAtualizado.IdSala = Evento.IdSala;
            context.Evento.Update(eventoAtualizado);
            await context.SaveChangesAsync();// atualização do banco é feita aqui
        return eventoAtualizado;
        }

     
        public async Task<ActionResult<Evento>> Delete(int id, Evento Evento)
        {
            Evento eventoAtualizado = await context.Evento.FindAsync(id);
          
            context.Evento.Remove(eventoAtualizado);
            await context.SaveChangesAsync();
            return eventoAtualizado;
        }
    }
}
