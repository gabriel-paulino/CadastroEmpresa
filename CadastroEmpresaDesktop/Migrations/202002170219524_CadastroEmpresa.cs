namespace CadastroEmpresaDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CadastroEmpresa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataSituacao = c.String(),
                        Nome = c.String(),
                        Efr = c.String(),
                        Uf = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                        Situacao = c.String(),
                        Bairro = c.String(),
                        Logradouro = c.String(),
                        Numero = c.String(),
                        Cep = c.String(),
                        Municipio = c.String(),
                        Porte = c.String(),
                        Abertura = c.String(),
                        NaturezaJuridica = c.String(),
                        Fantasia = c.String(),
                        Cnpj = c.String(),
                        UltimaAtualizacao = c.String(),
                        Status = c.String(),
                        Tipo = c.String(),
                        Complemento = c.String(),
                        MotivoSituacao = c.String(),
                        SituacaoEspecial = c.String(),
                        DataSituacaoEspecial = c.String(),
                        CapitalSocial = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AtividadePrincipals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Code = c.String(),
                        Empresa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresas", t => t.Empresa_Id)
                .Index(t => t.Empresa_Id);
            
            CreateTable(
                "dbo.AtividadesSecundarias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Code = c.String(),
                        Empresa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresas", t => t.Empresa_Id)
                .Index(t => t.Empresa_Id);
            
            CreateTable(
                "dbo.Qsas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qual = c.String(),
                        Nome = c.String(),
                        Empresa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresas", t => t.Empresa_Id)
                .Index(t => t.Empresa_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qsas", "Empresa_Id", "dbo.Empresas");
            DropForeignKey("dbo.AtividadesSecundarias", "Empresa_Id", "dbo.Empresas");
            DropForeignKey("dbo.AtividadePrincipals", "Empresa_Id", "dbo.Empresas");
            DropIndex("dbo.Qsas", new[] { "Empresa_Id" });
            DropIndex("dbo.AtividadesSecundarias", new[] { "Empresa_Id" });
            DropIndex("dbo.AtividadePrincipals", new[] { "Empresa_Id" });
            DropTable("dbo.Qsas");
            DropTable("dbo.AtividadesSecundarias");
            DropTable("dbo.AtividadePrincipals");
            DropTable("dbo.Empresas");
        }
    }
}
