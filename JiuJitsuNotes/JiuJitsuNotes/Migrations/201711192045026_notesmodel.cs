namespace JiuJitsuNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notesmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false),
                        PositionName = c.String(),
                    })
                .PrimaryKey(t => t.PositionID);
            
            CreateTable(
                "dbo.Techniques",
                c => new
                    {
                        TechniqueID = c.Int(nullable: false, identity: true),
                        TechniqueName = c.String(),
                        StartPositionID = c.Int(nullable: false),
                        EndPositionID = c.Int(nullable: false),
                        TechniqueType = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        StartingCondition = c.String(),
                        Steps = c.String(),
                        KeyPoints = c.String(),
                        CommonMistakes = c.String(),
                        Positions_PositionID = c.Int(),
                    })
                .PrimaryKey(t => t.TechniqueID)
                .ForeignKey("dbo.Positions", t => t.EndPositionID, cascadeDelete: false)
                .ForeignKey("dbo.Positions", t => t.StartPositionID, cascadeDelete: false)
                .ForeignKey("dbo.Positions", t => t.Positions_PositionID)
                .Index(t => t.StartPositionID)
                .Index(t => t.EndPositionID)
                .Index(t => t.Positions_PositionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Techniques", "Positions_PositionID", "dbo.Positions");
            DropForeignKey("dbo.Techniques", "StartPositionID", "dbo.Positions");
            DropForeignKey("dbo.Techniques", "EndPositionID", "dbo.Positions");
            DropIndex("dbo.Techniques", new[] { "Positions_PositionID" });
            DropIndex("dbo.Techniques", new[] { "EndPositionID" });
            DropIndex("dbo.Techniques", new[] { "StartPositionID" });
            DropTable("dbo.Techniques");
            DropTable("dbo.Positions");
        }
    }
}
