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
    public class UsuarioController : ControllerBase
    {

        AgendaThoughtWorksContext context = new AgendaThoughtWorksContext();
        UsuarioRepositorio repositorio = new UsuarioRepositorio();

        /// <summary>
        /// Altera os dados do usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put(Usuario usuario)
        {

            {
                Usuario usuarioAlterado = await context.Usuario.FindAsync(id);
                usuarioAlterado.Email = Usuario.Email;
                usuarioAlterado.Senha = Usuario.Senha;
                usuarioAlterado.IdUsuario = Usuario.IdUsuario;
                usuarioAlterado.IdTipoUsuario = Usuario.IdTipoUsuario;
                context.Usuario.Update(usuarioAlterado);
                await context.SaveChangesAsync();
                return NoContent();
            }

        }
        /// <summary>
        //Cria um novo usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Atualiza um novo usuário para o banco</returns>
        [HttpPost("{id}")]

        public async Task<ActionResult> post(Usuario usuario)
        {

            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Email = usuario.Email;
            usuario.Senha = usuario.Senha;
            context.Usuario.Update(usuario);

            await context.SaveChangesAsync();


            return NoContent();



        }
    }
}