namespace MyDynastyHomesAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMyHousToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MyHous_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "MyHous_ID");
            AddForeignKey("dbo.AspNetUsers", "MyHous_ID", "dbo.MyHouses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "MyHous_ID", "dbo.MyHouses");
            DropIndex("dbo.AspNetUsers", new[] { "MyHous_ID" });
            DropColumn("dbo.AspNetUsers", "MyHous_ID");
        }
    }
}
