using System.Threading.Tasks;
using APITW.Models;

namespace APITW.Interfaces
{
    public interface UsuarioInterface
    {
         
         Task <Usuario> Post (Usuario usuario);

         Task <Usuario> Put (int id , Usuario usuario);
    }
}