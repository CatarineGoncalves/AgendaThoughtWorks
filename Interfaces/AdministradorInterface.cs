using System.Threading.Tasks;
using APITW.Models;

namespace APITW.Interfaces
{
    public interface AdministradorInterface
    {
        Task <Administrador> Post (Administrador administrador);
    }
}