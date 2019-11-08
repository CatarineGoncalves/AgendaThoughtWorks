using System.Threading.Tasks;
using APITW.Models;

namespace APITW.Interfaces
{
    public interface InterfaceComunidade 
    {
    
        Task <Comunidade > Post (Comunidade comunidade);

         Task <Comunidade> Put (int id , Comunidade comunidade);

    }

 }
