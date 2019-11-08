using System.Threading.Tasks;
using APITW.Interfaces;
using APITW.Models;

namespace APITW.Repositorios
{
    public class UsuarioRepositorio :  UsuarioInterface
    {
          AgendaThoughtWorksContext context =  new AgendaThoughtWorksContext();
        public async Task<Usuario> Post(Usuario usuario)
        {
           await context.AddAsync(usuario);
           await context.SaveChangesAsync();
           return usuario;
        }

        public async Task<Usuario> Put(int id, Usuario usuario)
        {
            context.Usuario.Update(usuario);
            context.Usuario.Update(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }
    }
    }
