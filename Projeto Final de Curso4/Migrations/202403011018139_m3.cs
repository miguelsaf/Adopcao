namespace Projeto_Final_de_Curso4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_cliente");
            AddColumn("dbo.tb_cliente", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.tb_cliente", "AspNetUsers_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.tb_cliente", "Id");
            CreateIndex("dbo.tb_cliente", "AspNetUsers_Id");
            AddForeignKey("dbo.tb_cliente", "AspNetUsers_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.tb_cliente", "id_cliente");
            DropColumn("dbo.tb_cliente", "id_usuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_cliente", "id_usuario", c => c.String(maxLength: 128));
            AddColumn("dbo.tb_cliente", "id_cliente", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.tb_cliente", "AspNetUsers_Id", "dbo.AspNetUsers");
            DropIndex("dbo.tb_cliente", new[] { "AspNetUsers_Id" });
            DropPrimaryKey("dbo.tb_cliente");
            DropColumn("dbo.tb_cliente", "AspNetUsers_Id");
            DropColumn("dbo.tb_cliente", "Id");
            AddPrimaryKey("dbo.tb_cliente", "id_cliente");
        }
    }
}
