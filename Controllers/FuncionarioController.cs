using System.Threading.Tasks;
using APITW.Models;
using APITW.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITW.Controllers
{
    public class FuncionarioController
    {
        
        [Route("api/[controller]")]
        [ApiController]
        [Produces("application/json")]
    public class ComunidadeController : ControllerBase
    {


        AgendaThoughtWorksContext context = new AgendaThoughtWorksContext();
        FuncionarioRepositorio repositorio = new FuncionarioRepositorio();

        /// <summary>
        /// funcionario envia as informações do funcionario 
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>retorna as informações do funcionário em formato task</returns>
        [HttpPost]
        public async Task<ActionResult<Funcionario>> Post(Funcionario funcionario)
        {
            try
            {
                 return await repositorio.Post(funcionario);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }   
    } 

  }

}

