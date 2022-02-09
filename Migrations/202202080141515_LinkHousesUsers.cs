namespace MyDynastyHomesAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkHousesUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyHouses", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.MyHouses", "UserId");
            AddForeignKey("dbo.MyHouses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyHouses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.MyHouses", new[] { "UserId" });
            DropColumn("dbo.MyHouses", "UserId");
        }
    }
}
