namespace MyDynastyHomesAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKGoneNotColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bathroom", "RepairMultiplier_ID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Exterior", "RepairMultiplier_ID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Interior", "RepairMultiplier_ID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Kitchen", "RepairMultiplier_ID", "dbo.RepairMultipliers");
            DropForeignKey("dbo.Utilities", "RepairMultiplier_ID", "dbo.RepairMultipliers");
            DropIndex("dbo.Bathroom", new[] { "RepairMultiplier_ID" });
            DropIndex("dbo.Exterior", new[] { "RepairMultiplier_ID" });
            DropIndex("dbo.Interior", new[] { "RepairMultiplier_ID" });
            DropIndex("dbo.Kitchen", new[] { "RepairMultiplier_ID" });
            DropIndex("dbo.Utilities", new[] { "RepairMultiplier_ID" });
            AlterColumn("dbo.Utilities", "Furnaces", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Utilities", "AirConditioning_Units", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Utilities", "Hot_Water_Heater", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Utilities", "Electric", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Utilities", "Plumbing", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Utilities", "Sewer", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Utilities", "RepairCost", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Bathroom", "RepairMultiplier_ID");
            DropColumn("dbo.Exterior", "RepairMultiplier_ID");
            DropColumn("dbo.Interior", "RepairMultiplier_ID");
            DropColumn("dbo.Kitchen", "RepairMultiplier_ID");
            DropColumn("dbo.Utilities", "HouseID");
            DropColumn("dbo.Utilities", "RenovationCostID");
            DropColumn("dbo.Utilities", "RepairMultiplier_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilities", "RepairMultiplier_ID", c => c.Int());
            AddColumn("dbo.Utilities", "RenovationCostID", c => c.Int(nullable: false));
            AddColumn("dbo.Utilities", "HouseID", c => c.Int(nullable: false));
            AddColumn("dbo.Kitchen", "RepairMultiplier_ID", c => c.Int());
            AddColumn("dbo.Interior", "RepairMultiplier_ID", c => c.Int());
            AddColumn("dbo.Exterior", "RepairMultiplier_ID", c => c.Int());
            AddColumn("dbo.Bathroom", "RepairMultiplier_ID", c => c.Int());
            AlterColumn("dbo.Utilities", "RepairCost", c => c.Int());
            AlterColumn("dbo.Utilities", "Sewer", c => c.Int(nullable: false));
            AlterColumn("dbo.Utilities", "Plumbing", c => c.Int(nullable: false));
            AlterColumn("dbo.Utilities", "Electric", c => c.Int(nullable: false));
            AlterColumn("dbo.Utilities", "Hot_Water_Heater", c => c.Int(nullable: false));
            AlterColumn("dbo.Utilities", "AirConditioning_Units", c => c.Int(nullable: false));
            AlterColumn("dbo.Utilities", "Furnaces", c => c.Int(nullable: false));
            CreateIndex("dbo.Utilities", "RepairMultiplier_ID");
            CreateIndex("dbo.Kitchen", "RepairMultiplier_ID");
            CreateIndex("dbo.Interior", "RepairMultiplier_ID");
            CreateIndex("dbo.Exterior", "RepairMultiplier_ID");
            CreateIndex("dbo.Bathroom", "RepairMultiplier_ID");
            AddForeignKey("dbo.Utilities", "RepairMultiplier_ID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Kitchen", "RepairMultiplier_ID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Interior", "RepairMultiplier_ID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Exterior", "RepairMultiplier_ID", "dbo.RepairMultipliers", "ID");
            AddForeignKey("dbo.Bathroom", "RepairMultiplier_ID", "dbo.RepairMultipliers", "ID");
        }
    }
}
