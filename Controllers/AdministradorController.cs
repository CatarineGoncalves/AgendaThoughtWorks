using System.Threading.Tasks;
using APITW.Models;
using APITW.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITW.Controllers
{
    public class AdministradorController
    {

        [Route("api/[controller]")]
        [ApiController]
        [Produces("application/json")]
        public class ComunidadeController : ControllerBase
        {


            AgendaThoughtWorksContext context = new AgendaThoughtWorksContext();
            AdministradorRepositorio repositorio = new AdministradorRepositorio();

            /// <summary>
            /// Método usado para alterar o nome do administrador
            /// </summary>
            /// <param name="administrador"></param>
            /// <returns>Retorna o nome atualizado </returns>
            [HttpPost]
            public async Task<ActionResult<Administrador>> Post(Administrador administrador)
            {
                Administrador administradorNome = await context.Administrador.FindAsync(id);
                administradorNome.Nome = Administrador.Nome;
                administrador.IdUsuario = Administrador.IdUsuario;
                context.Administrador.Update(administradorNome);
                await context.SaveChangesAsync();
                return NoContent();

            }
/// <summary>
/// Método usado para atualizar os dados do administrador com a id correspondente
/// </summary>
/// <param name="administrador"></param>
/// <returns>Retorna o nome atualizado com a id correspondente</returns>
            [HttpPut ("{id}")]
 public async Task<ActionResult> put (Administrador administrador)
 {
     if (Comunidade == null)
     {
         return NotFound();
     }
     administrador.Nome = administrador.Nome;
     context.Administrador.Update(administrador);

await context.SaveChangesAsync();
return NoContent();
 }
        }

    }
}