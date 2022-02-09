namespace MyDynastyHomesAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllDecimals : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MyHouses", "LotSize", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.MyHouses", "SquareFootage", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.MyHouses", "Stories", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.MyHouses", "BedroomCount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.MyHouses", "BathroomCount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.MyHouses", "RoomCount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Bathroom", "Number_Of_Sinks", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Bathroom", "Number_Of_Toilets", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Bathroom", "Number_Of_Showers", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Bathroom", "RepairCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Exterior", "_Windows", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Exterior", "Siding_SQFT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Exterior", "Roof_SQFT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Exterior", "Number_Of_Foundation_Walls", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Exterior", "Number_Of_Doors", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Exterior", "Number_Of_Trees", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Exterior", "RepairCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Interior", "Paint_Number_Of_Rooms", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Interior", "Drywall_SQFT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Interior", "Floors_SQFT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Interior", "Number_Of_Light_Fixtures", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Interior", "Baseboard_Linear_Foot", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Interior", "Subfloor_SQFT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Interior", "RepairCost", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Kitchen", "Refrigerator", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Kitchen", "Oven", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Kitchen", "Microwave", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Kitchen", "Dishwasher", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Kitchen", "Garbage_Disposal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Kitchen", "Cabinets", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Kitchen", "Counter_Tops_SQFT", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Kitchen", "Sink", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Kitchen", "RepairCost", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Exterior", "HouseID");
            DropColumn("dbo.Exterior", "RenovationCostID");
            DropColumn("dbo.Interior", "HouseID");
            DropColumn("dbo.Interior", "RenovationCostID");
            DropColumn("dbo.Kitchen", "HouseID");
            DropColumn("dbo.Kitchen", "RenovationCostID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kitchen", "RenovationCostID", c => c.Int(nullable: false));
            AddColumn("dbo.Kitchen", "HouseID", c => c.Int(nullable: false));
            AddColumn("dbo.Interior", "RenovationCostID", c => c.Int(nullable: false));
            AddColumn("dbo.Interior", "HouseID", c => c.Int(nullable: false));
            AddColumn("dbo.Exterior", "RenovationCostID", c => c.Int(nullable: false));
            AddColumn("dbo.Exterior", "HouseID", c => c.Int(nullable: false));
            AlterColumn("dbo.Kitchen", "RepairCost", c => c.Int());
            AlterColumn("dbo.Kitchen", "Sink", c => c.Int(nullable: false));
            AlterColumn("dbo.Kitchen", "Counter_Tops_SQFT", c => c.Int(nullable: false));
            AlterColumn("dbo.Kitchen", "Cabinets", c => c.Int(nullable: false));
            AlterColumn("dbo.Kitchen", "Garbage_Disposal", c => c.Int(nullable: false));
            AlterColumn("dbo.Kitchen", "Dishwasher", c => c.Int(nullable: false));
            AlterColumn("dbo.Kitchen", "Microwave", c => c.Int(nullable: false));
            AlterColumn("dbo.Kitchen", "Oven", c => c.Int(nullable: false));
            AlterColumn("dbo.Kitchen", "Refrigerator", c => c.Int(nullable: false));
            AlterColumn("dbo.Interior", "RepairCost", c => c.Int());
            AlterColumn("dbo.Interior", "Subfloor_SQFT", c => c.Int(nullable: false));
            AlterColumn("dbo.Interior", "Baseboard_Linear_Foot", c => c.Int(nullable: false));
            AlterColumn("dbo.Interior", "Number_Of_Light_Fixtures", c => c.Int(nullable: false));
            AlterColumn("dbo.Interior", "Floors_SQFT", c => c.Int(nullable: false));
            AlterColumn("dbo.Interior", "Drywall_SQFT", c => c.Int(nullable: false));
            AlterColumn("dbo.Interior", "Paint_Number_Of_Rooms", c => c.Int(nullable: false));
            AlterColumn("dbo.Exterior", "RepairCost", c => c.Int());
            AlterColumn("dbo.Exterior", "Number_Of_Trees", c => c.Int(nullable: false));
            AlterColumn("dbo.Exterior", "Number_Of_Doors", c => c.Int(nullable: false));
            AlterColumn("dbo.Exterior", "Number_Of_Foundation_Walls", c => c.Int(nullable: false));
            AlterColumn("dbo.Exterior", "Roof_SQFT", c => c.Int(nullable: false));
            AlterColumn("dbo.Exterior", "Siding_SQFT", c => c.Int(nullable: false));
            AlterColumn("dbo.Exterior", "_Windows", c => c.Int(nullable: false));
            AlterColumn("dbo.Bathroom", "RepairCost", c => c.Int(nullable: false));
            AlterColumn("dbo.Bathroom", "Number_Of_Showers", c => c.Int(nullable: false));
            AlterColumn("dbo.Bathroom", "Number_Of_Toilets", c => c.Int(nullable: false));
            AlterColumn("dbo.Bathroom", "Number_Of_Sinks", c => c.Int(nullable: false));
            AlterColumn("dbo.MyHouses", "RoomCount", c => c.Int());
            AlterColumn("dbo.MyHouses", "BathroomCount", c => c.Int());
            AlterColumn("dbo.MyHouses", "BedroomCount", c => c.Int());
            AlterColumn("dbo.MyHouses", "Stories", c => c.Int());
            AlterColumn("dbo.MyHouses", "SquareFootage", c => c.Int());
            AlterColumn("dbo.MyHouses", "LotSize", c => c.Int());
        }
    }
}
