using CadastroEmpresa.Serialization;
using System.Data.Entity;

namespace CadastroEmpresaDesktop
{
    public class Context :DbContext 
    {
        public DbSet<Empresa> Empresas { get; set; }
    }
}
