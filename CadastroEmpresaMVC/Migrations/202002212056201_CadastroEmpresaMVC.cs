namespace CadastroEmpresaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CadastroEmpresaMVC : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AtividadePrincipal", name: "Cnpj", newName: "EmpresaID");
            RenameColumn(table: "dbo.AtividadesSecundaria", name: "Cnpj", newName: "EmpresaID");
            RenameColumn(table: "dbo.Qsa", name: "Cnpj", newName: "EmpresaID");
            RenameIndex(table: "dbo.AtividadePrincipal", name: "IX_Cnpj", newName: "IX_EmpresaID");
            RenameIndex(table: "dbo.AtividadesSecundaria", name: "IX_Cnpj", newName: "IX_EmpresaID");
            RenameIndex(table: "dbo.Qsa", name: "IX_Cnpj", newName: "IX_EmpresaID");
            AlterColumn("dbo.Empresa", "Cnpj", c => c.String(nullable: false));
            AlterColumn("dbo.Empresa", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empresa", "Nome", c => c.String());
            AlterColumn("dbo.Empresa", "Cnpj", c => c.String());
            RenameIndex(table: "dbo.Qsa", name: "IX_EmpresaID", newName: "IX_Cnpj");
            RenameIndex(table: "dbo.AtividadesSecundaria", name: "IX_EmpresaID", newName: "IX_Cnpj");
            RenameIndex(table: "dbo.AtividadePrincipal", name: "IX_EmpresaID", newName: "IX_Cnpj");
            RenameColumn(table: "dbo.Qsa", name: "EmpresaID", newName: "Cnpj");
            RenameColumn(table: "dbo.AtividadesSecundaria", name: "EmpresaID", newName: "Cnpj");
            RenameColumn(table: "dbo.AtividadePrincipal", name: "EmpresaID", newName: "Cnpj");
        }
    }
}
