using System.Threading.Tasks;
using APITW.Interfaces;
using APITW.Models;

namespace APITW.Repositorios
{
    
         public class ComunidadeRepositorio : InterfaceComunidade
    {   
        AgendaThoughtWorksContext context =  new AgendaThoughtWorksContext();
        public async Task<Comunidade> Post(Comunidade comunidade)
        {
           await context.AddAsync(comunidade);
           await context.SaveChangesAsync();
           return comunidade;
        }

        public async Task<Comunidade> Put(int id, Comunidade comunidade)
        {
            context.Comunidade.Update(comunidade);
            context.Comunidade.Update(comunidade);
            await context.SaveChangesAsync();
            return comunidade;
        }

      
    }
    }
