namespace JiuJitsuNotes.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using JiuJitsuNotes.Models;
    using jiujitsuNotes.Models.NotesModel;

    internal sealed class Configuration : DbMigrationsConfiguration<JiuJitsuNotes.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JiuJitsuNotes.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Positions.AddOrUpdate(
              p => p.PositionName,
              new Positions { PositionID = 1, PositionName = "Standing" },
              new Positions { PositionID = 2, PositionName = "Full Gaurd" },
              new Positions
              {
                  PositionID = 3,
                  PositionName = "Mount",
                  Techniques = new List<Techniques>()
              { new Techniques { TechniqueName="Test", DateAdded=DateTime.Now, CommonMistakes="TestMistake", EndPositionID=2, StartPositionID=3, KeyPoints="TestPoint", StartingCondition="Start cond", Steps="Test Steps", TechniqueType = TechniqueType.Escape }
              }

              });

        }
    }
}
