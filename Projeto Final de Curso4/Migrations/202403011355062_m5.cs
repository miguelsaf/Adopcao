namespace Projeto_Final_de_Curso4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_adopcao", "motivo_da_adopcao", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_adopcao", "motivo_da_adopcao");
        }
    }
}
