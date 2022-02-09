namespace MyDynastyHomesAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairsDecimals : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RepairMultipliers", "BathroomSink", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Toilet", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Shower", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Window", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "SidingPerSQFT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Roof", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "FoundationWall", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "ExteriorDoor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "TreeRemoval", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "PaintPerRoom", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "DrywallPerSQFT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "FloorsPerSQFT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "LightFixture", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Baseboards", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "SubfloorPerSQFT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Refrigerator", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Oven", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Microwave", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Dishwasher", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "GarbageDisposal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Cabinet", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "CounterTopsPerSQFT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "KitchenSink", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "FurnacePerStory", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "AirConditioningUnitPerStory", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "HotWaterHeater", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Electric", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Plumbing", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RepairMultipliers", "Sewer", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairMultipliers", "Sewer", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Plumbing", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Electric", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "HotWaterHeater", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "AirConditioningUnitPerStory", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "FurnacePerStory", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "KitchenSink", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "CounterTopsPerSQFT", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Cabinet", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "GarbageDisposal", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Dishwasher", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Microwave", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Oven", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Refrigerator", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "SubfloorPerSQFT", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Baseboards", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "LightFixture", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "FloorsPerSQFT", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "DrywallPerSQFT", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "PaintPerRoom", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "TreeRemoval", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "ExteriorDoor", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "FoundationWall", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Roof", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "SidingPerSQFT", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Window", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Shower", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "Toilet", c => c.Int(nullable: false));
            AlterColumn("dbo.RepairMultipliers", "BathroomSink", c => c.Int(nullable: false));
        }
    }
}
