using System.Threading.Tasks;
using APITW.Models;
using APITW.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITW.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        [Produces("application/json")]
    public class ComunidadeController : ControllerBase
    {


        AgendaThoughtWorksContext context = new AgendaThoughtWorksContext();
        ComunidadeRepositorio repositorio = new ComunidadeRepositorio ();

        /// <summary>
        /// Método usado para cadastrar a comunidade no sistema a partir do preenchimento
        /// </summary>
        /// <param name="comunidade"></param>
        /// <returns>Retorna um novo registro de comunidade com o id atualizado para o banco</returns>
        [HttpPost]
        public async Task<ActionResult<Comunidade>> Post(Comunidade comunidade)
        {
           Comunidade comunidadeCadastro = await context.Comunidade.FindAsync(id);
           comunidadeCadastro.NomeComunidade =  Comunidade.NomeComunidade;
           comunidadeCadastro.NomeResponsavel = Comunidade.NomeResponsavel;
           comunidadeCadastro.ContatoComunidade = Comunidade.ContatoComunidade;
           comunidadeCadastro.FotoComunidade = Comunidade.FotoComunidade;
           comunidadeCadastro.IdComunidade = Comunidade.IdComunidade;
           comunidadeCadastro.IdUsuario = Comunidade.IdUsuario;
           context.Comunidade.Update (comunidadeCadastro);
           await context.SaveChangesAsync();
           return NoContent();
        }
        /// <summary>
        /// Método usado para atualizar as informações da comunidade
        /// </summary>
        /// <param name="comunidade"></param>
        /// <returns>Retorna as informações atualizadas para o banco com a id correspondente</returns>
        [HttpPut("{id}")]

        public async Task<ActionResult> put(Comunidade comunidade)
       {
            
            if (comunidade == null)
            {
                return NotFound();
            }
            comunidade.NomeComunidade = comunidade.NomeComunidade;
            comunidade.NomeResponsavel = comunidade.NomeResponsavel;
            context.Comunidade.Update(comunidade);
            
            await context.SaveChangesAsync();
            

            return NoContent();

           
       }


        
    }
    }
