namespace CadastroEmpresaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AtividadePrincipal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Code = c.String(),
                        Cnpj = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Cnpj, cascadeDelete: true)
                .Index(t => t.Cnpj);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cnpj = c.String(),
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
                "dbo.AtividadesSecundaria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Code = c.String(),
                        Cnpj = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Cnpj, cascadeDelete: true)
                .Index(t => t.Cnpj);
            
            CreateTable(
                "dbo.Qsa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qual = c.String(),
                        Nome = c.String(),
                        Cnpj = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Cnpj, cascadeDelete: true)
                .Index(t => t.Cnpj);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qsa", "Cnpj", "dbo.Empresa");
            DropForeignKey("dbo.AtividadesSecundaria", "Cnpj", "dbo.Empresa");
            DropForeignKey("dbo.AtividadePrincipal", "Cnpj", "dbo.Empresa");
            DropIndex("dbo.Qsa", new[] { "Cnpj" });
            DropIndex("dbo.AtividadesSecundaria", new[] { "Cnpj" });
            DropIndex("dbo.AtividadePrincipal", new[] { "Cnpj" });
            DropTable("dbo.Qsa");
            DropTable("dbo.AtividadesSecundaria");
            DropTable("dbo.Empresa");
            DropTable("dbo.AtividadePrincipal");
        }
    }
}
