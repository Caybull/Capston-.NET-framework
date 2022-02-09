namespace MyDynastyHomesAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFKRepair : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bathroom", "MultiplierID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Exterior", "MultiplierID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Interior", "MultiplierID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Kitchen", "MultiplierID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Utilities", "MultiplierID", "dbo.RepairMultipliers");
            DropIndex("dbo.Bathroom", new[] { "MultiplierID" });
            DropIndex("dbo.Exterior", new[] { "MultiplierID" });
            DropIndex("dbo.Interior", new[] { "MultiplierID" });
            DropIndex("dbo.Kitchen", new[] { "MultiplierID" });
            DropIndex("dbo.Utilities", new[] { "MultiplierID" });
            AddColumn("dbo.Bathroom", "RepairMultiplier_ID", c => c.Int());
            AddColumn("dbo.Exterior", "RepairMultiplier_ID", c => c.Int());
            AddColumn("dbo.Interior", "RepairMultiplier_ID", c => c.Int());
            AddColumn("dbo.Kitchen", "RepairMultiplier_ID", c => c.Int());
            AddColumn("dbo.Utilities", "RepairMultiplier_ID", c => c.Int());
            CreateIndex("dbo.Bathroom", "RepairMultiplier_ID");
            CreateIndex("dbo.Exterior", "RepairMultiplier_ID");
            CreateIndex("dbo.Interior", "RepairMultiplier_ID");
            CreateIndex("dbo.Kitchen", "RepairMultiplier_ID");
            CreateIndex("dbo.Utilities", "RepairMultiplier_ID");
            AddForeignKey("dbo.Bathroom", "RepairMultiplier_ID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Exterior", "RepairMultiplier_ID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Interior", "RepairMultiplier_ID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Kitchen", "RepairMultiplier_ID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Utilities", "RepairMultiplier_ID", "dbo.RepairMultipliers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Utilities", "RepairMultiplier_ID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Kitchen", "RepairMultiplier_ID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Interior", "RepairMultiplier_ID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Exterior", "RepairMultiplier_ID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Bathroom", "RepairMultiplier_ID", "dbo.RepairMultipliers");
            DropIndex("dbo.Utilities", new[] { "RepairMultiplier_ID" });
            DropIndex("dbo.Kitchen", new[] { "RepairMultiplier_ID" });
            DropIndex("dbo.Interior", new[] { "RepairMultiplier_ID" });
            DropIndex("dbo.Exterior", new[] { "RepairMultiplier_ID" });
            DropIndex("dbo.Bathroom", new[] { "RepairMultiplier_ID" });
            DropColumn("dbo.Utilities", "RepairMultiplier_ID");
            DropColumn("dbo.Kitchen", "RepairMultiplier_ID");
            DropColumn("dbo.Interior", "RepairMultiplier_ID");
            DropColumn("dbo.Exterior", "RepairMultiplier_ID");
            DropColumn("dbo.Bathroom", "RepairMultiplier_ID");
            CreateIndex("dbo.Utilities", "MultiplierID");
            CreateIndex("dbo.Kitchen", "MultiplierID");
            CreateIndex("dbo.Interior", "MultiplierID");
            CreateIndex("dbo.Exterior", "MultiplierID");
            CreateIndex("dbo.Bathroom", "MultiplierID");
            AddForeignKey("dbo.Utilities", "MultiplierID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Kitchen", "MultiplierID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Interior", "MultiplierID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Exterior", "MultiplierID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Bathroom", "MultiplierID", "dbo.RepairMultipliers", "ID");
        }
    }
}
