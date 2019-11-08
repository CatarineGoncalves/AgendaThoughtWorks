using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APITW.Models;
using Back_TW.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_tw.Repositorio
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        AgendaThoughtWorksContext context = new AgendaThoughtWorksContext();
        EventoRepositorio repositorio = new EventoRepositorio();
     

       /// <summary>
       /// /// Método get para o usuário visualizar as informações
       /// </summary>
       /// <returns>Retorna uma lista de eventos </returns>
       [HttpGet]
       public async Task<ActionResult<List<Evento>>> Get()
       {
              var listaDeEventos = await repositorio.Listar();
            if (listaDeEventos == null)
            {
                return NotFound();

            }
            return listaDeEventos;
       }
        /// <summary>
        /// Método de criação de eventos a partir do preenchimento put 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Evento"></param>
        /// <returns>Retorna um evento atualizado para um banco com a identificação id</returns>
        [HttpPut]
        public async Task<ActionResult> Put(int id, Evento Evento)
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
            return NoContent();
        }



        /// <summary>
        /// Método que deleta um evento permitido apenas para o funcionário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Evento"></param>
        /// <returns>retorna um evento deletado,atualizando o banco///C</returns>
       [Authorize(Roles = "Adminstrador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evento>> Delete(int id, Evento Evento)
        {
            Evento eventoAtualizado = await context.Evento.FindAsync(id);
            if (eventoAtualizado == null)
            {
                return NoContent();
            }
            context.Evento.Remove(eventoAtualizado);
            await context.SaveChangesAsync();
            return eventoAtualizado;
        }
    }
}
