using CadastroEmpresa.Serialization;
using Refit;
using System.Threading.Tasks;

namespace CadastroEmpresa
{
    public interface EmpresaApiService
    {
        [Get("/v1/cnpj/{cnpj}")]
        Task<Empresa> GetEmpresaAsync(string cnpj);
    }
}
