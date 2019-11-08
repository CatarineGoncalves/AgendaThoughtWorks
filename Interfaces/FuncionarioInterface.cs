using System.Threading.Tasks;
using APITW.Models;

namespace APITW.Interfaces
{
    public interface FuncionarioInterface
    {
         
        Task <Funcionario> Post (Funcionario funcionario);

    }
}