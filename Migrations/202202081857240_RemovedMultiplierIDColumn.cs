namespace MyDynastyHomesAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedMultiplierIDColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bathroom", "MultiplierID");
            DropColumn("dbo.Exterior", "MultiplierID");
            DropColumn("dbo.Interior", "MultiplierID");
            DropColumn("dbo.Kitchen", "MultiplierID");
            DropColumn("dbo.Utilities", "MultiplierID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilities", "MultiplierID", c => c.Int(nullable: false));
            AddColumn("dbo.Kitchen", "MultiplierID", c => c.Int(nullable: false));
            AddColumn("dbo.Interior", "MultiplierID", c => c.Int(nullable: false));
            AddColumn("dbo.Exterior", "MultiplierID", c => c.Int(nullable: false));
            AddColumn("dbo.Bathroom", "MultiplierID", c => c.Int(nullable: false));
        }
    }
}
