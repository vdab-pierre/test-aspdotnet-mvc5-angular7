namespace woordjesTestWebApiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Woordjes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WoordText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Woordjes");
        }
    }
}
