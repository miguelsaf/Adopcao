namespace Projeto_Final_de_Curso4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            
            
            CreateTable(
                "dbo.tb_adopcao",
                c => new
                    {
                        id_adopcao = c.Int(nullable: false, identity: true),
                        id_cliente = c.Int(nullable: false),
                        id_funcionario = c.Int(),
                        id_animal = c.Int(nullable: false),
                        id_estado_da_adopcao = c.Int(nullable: false),
                        data_de_entrega = c.String(maxLength: 50, unicode: false),
                        data_de_solicitacao_do_animal = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id_adopcao)
                .ForeignKey("dbo.tb_animal", t => t.id_animal)
                .ForeignKey("dbo.tb_estado_da_adopcao", t => t.id_estado_da_adopcao)
                .Index(t => t.id_animal)
                .Index(t => t.id_estado_da_adopcao);
            
            CreateTable(
                "dbo.tb_animal",
                c => new
                    {
                        id_animal = c.Int(nullable: false, identity: true),
                        id_cor = c.Int(nullable: false),
                        id_genero = c.Int(nullable: false),
                        id_tipo_de_animal = c.Int(nullable: false),
                        id_disponibilidade_do_animal = c.Int(nullable: false),
                        idade = c.String(maxLength: 50, unicode: false),
                        raca = c.String(maxLength: 50, unicode: false),
                        peso = c.String(maxLength: 50, unicode: false),
                        foto = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.id_animal)
                .ForeignKey("dbo.tb_cor", t => t.id_cor)
                .ForeignKey("dbo.tb_disponibilidade_do_animal", t => t.id_disponibilidade_do_animal)
                .ForeignKey("dbo.tb_genero", t => t.id_genero)
                .ForeignKey("dbo.tb_tipo_de_animal", t => t.id_tipo_de_animal)
                .Index(t => t.id_cor)
                .Index(t => t.id_genero)
                .Index(t => t.id_tipo_de_animal)
                .Index(t => t.id_disponibilidade_do_animal);
            
            CreateTable(
                "dbo.tb_cor",
                c => new
                    {
                        id_cor = c.Int(nullable: false, identity: true),
                        cor = c.String(maxLength: 40, unicode: false),
                    })
                .PrimaryKey(t => t.id_cor);
            
            CreateTable(
                "dbo.tb_disponibilidade_do_animal",
                c => new
                    {
                        id_disponibilidade_do_animal = c.Int(nullable: false, identity: true),
                        disponibilidade_do_animal = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id_disponibilidade_do_animal);
            
            CreateTable(
                "dbo.tb_genero",
                c => new
                    {
                        id_genero = c.Int(nullable: false, identity: true),
                        genero = c.String(maxLength: 40, unicode: false),
                    })
                .PrimaryKey(t => t.id_genero);
            
            CreateTable(
                "dbo.tb_cliente",
                c => new
                    {
                        id_cliente = c.Int(nullable: false, identity: true),
                        nome = c.String(maxLength: 50, unicode: false),
                        id_genero = c.Int(nullable: false),
                        bairro = c.String(maxLength: 50, unicode: false),
                        rua_casa = c.String(maxLength: 50, unicode: false),
                        contacto = c.Int(nullable: false),
                        n_BI = c.String(maxLength: 50, unicode: false),
                        id_municipio = c.Int(nullable: false),
                        id_usuario = c.String(maxLength: 128),
                        ocupacao = c.String(maxLength: 100, unicode: false),
                        data_de_nascimento = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id_cliente)
                .ForeignKey("dbo.tb_municipio", t => t.id_municipio)
                .ForeignKey("dbo.tb_genero", t => t.id_genero)
                .Index(t => t.id_genero)
                .Index(t => t.id_municipio);
            
            CreateTable(
                "dbo.tb_municipio",
                c => new
                    {
                        id_municipio = c.Int(nullable: false, identity: true),
                        municipio = c.String(maxLength: 40, unicode: false),
                    })
                .PrimaryKey(t => t.id_municipio);
            
            CreateTable(
                "dbo.tb_funcionario",
                c => new
                    {
                        id_funcionario = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50, unicode: false),
                        id_genero = c.Int(nullable: false),
                        bairro = c.String(maxLength: 50, unicode: false),
                        rua_casa = c.String(maxLength: 50, unicode: false),
                        contacto = c.Int(nullable: false),
                        n_BI = c.String(maxLength: 50, unicode: false),
                        id_municipio = c.Int(nullable: false),
                        id_usuario = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id_funcionario)
                .ForeignKey("dbo.tb_municipio", t => t.id_municipio)
                .ForeignKey("dbo.tb_genero", t => t.id_genero)
                .Index(t => t.id_genero)
                .Index(t => t.id_municipio);
            
            CreateTable(
                "dbo.tb_tipo_de_animal",
                c => new
                    {
                        id_tipo_de_animal = c.Int(nullable: false, identity: true),
                        tipo_de_animal = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id_tipo_de_animal);
            
            CreateTable(
                "dbo.tb_devolucao_de_animal",
                c => new
                    {
                        id_devolucao_de_animal = c.Int(nullable: false, identity: true),
                        id_adopcao = c.Int(nullable: false),
                        motivo_da_devolucao = c.String(maxLength: 200, unicode: false),
                        data_da_devolucao = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id_devolucao_de_animal)
                .ForeignKey("dbo.tb_adopcao", t => t.id_adopcao)
                .Index(t => t.id_adopcao);
            
            CreateTable(
                "dbo.tb_estado_da_adopcao",
                c => new
                    {
                        id_estado_da_adopcao = c.Int(nullable: false, identity: true),
                        estado_da_adopcao = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id_estado_da_adopcao);
            
            
        }
        
        public override void Down()
        {
            
            
            DropForeignKey("dbo.tb_adopcao", "id_estado_da_adopcao", "dbo.tb_estado_da_adopcao");
            DropForeignKey("dbo.tb_devolucao_de_animal", "id_adopcao", "dbo.tb_adopcao");
            DropForeignKey("dbo.tb_animal", "id_tipo_de_animal", "dbo.tb_tipo_de_animal");
            DropForeignKey("dbo.tb_funcionario", "id_genero", "dbo.tb_genero");
            DropForeignKey("dbo.tb_cliente", "id_genero", "dbo.tb_genero");
            DropForeignKey("dbo.tb_funcionario", "id_municipio", "dbo.tb_municipio");
            DropForeignKey("dbo.tb_cliente", "id_municipio", "dbo.tb_municipio");
            DropForeignKey("dbo.tb_animal", "id_genero", "dbo.tb_genero");
            DropForeignKey("dbo.tb_animal", "id_disponibilidade_do_animal", "dbo.tb_disponibilidade_do_animal");
            DropForeignKey("dbo.tb_animal", "id_cor", "dbo.tb_cor");
            DropForeignKey("dbo.tb_adopcao", "id_animal", "dbo.tb_animal");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.tb_devolucao_de_animal", new[] { "id_adopcao" });
            DropIndex("dbo.tb_funcionario", new[] { "id_municipio" });
            DropIndex("dbo.tb_funcionario", new[] { "id_genero" });
            DropIndex("dbo.tb_cliente", new[] { "id_municipio" });
            DropIndex("dbo.tb_cliente", new[] { "id_genero" });
            DropIndex("dbo.tb_animal", new[] { "id_disponibilidade_do_animal" });
            DropIndex("dbo.tb_animal", new[] { "id_tipo_de_animal" });
            DropIndex("dbo.tb_animal", new[] { "id_genero" });
            DropIndex("dbo.tb_animal", new[] { "id_cor" });
            DropIndex("dbo.tb_adopcao", new[] { "id_estado_da_adopcao" });
            DropIndex("dbo.tb_adopcao", new[] { "id_animal" });
            
            DropTable("dbo.tb_estado_da_adopcao");
            DropTable("dbo.tb_devolucao_de_animal");
            DropTable("dbo.tb_tipo_de_animal");
            DropTable("dbo.tb_funcionario");
            DropTable("dbo.tb_municipio");
            DropTable("dbo.tb_cliente");
            DropTable("dbo.tb_genero");
            DropTable("dbo.tb_disponibilidade_do_animal");
            DropTable("dbo.tb_cor");
            DropTable("dbo.tb_animal");
            DropTable("dbo.tb_adopcao");
            
        }
    }
}
