using System.Threading.Tasks;
using APITW.Interfaces;
using APITW.Models;

namespace APITW.Repositorios
{
    public class AdministradorRepositorio : AdministradorInterface
    {
         AgendaThoughtWorksContext context =  new AgendaThoughtWorksContext();
        public async Task<Administrador> Post(Administrador administrador)
        {
           await context.AddAsync(administrador);
           await context.SaveChangesAsync();
           return administrador;
        }

        
    }
}