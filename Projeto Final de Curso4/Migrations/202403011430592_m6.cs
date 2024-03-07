namespace Projeto_Final_de_Curso4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_adopcao", "id_cliente", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_adopcao", "id_cliente", c => c.Int(nullable: false));
        }
    }
}
