using System.Threading.Tasks;
using APITW.Interfaces;
using APITW.Models;

namespace APITW.Repositorios
{
    public class FuncionarioRepositorio : FuncionarioInterface
    {   
         AgendaThoughtWorksContext context =  new AgendaThoughtWorksContext();
        public async Task<Funcionario> Post(Funcionario funcionario)
        {
           await context.AddAsync(funcionario);
           await context.SaveChangesAsync();
           return funcionario;
        }
    }
}