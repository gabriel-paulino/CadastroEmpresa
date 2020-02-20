using CadastroEmpresaMVC.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CadastroEmpresaMVC.DAL
{
    public class Context : DbContext
    {
        public Context() : base("CadastroEmpresaMVC") { }

        //Método para remover os plurais criados 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<AtividadePrincipal> AtividadePrincipals { get; set; }
        public DbSet<AtividadesSecundaria> AtividadesSecundarias { get; set; }
        public DbSet<Qsa> Qsas { get; set; }
    }
}