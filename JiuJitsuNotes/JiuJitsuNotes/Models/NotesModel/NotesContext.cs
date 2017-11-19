using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace jiujitsu.Models.TechniquesModel
{
    public class NotesContext : DbContext
    {
        public DbSet<Techniques> Techniques { get; set; }
        public DbSet<Positions> Postions { get; set; }
        public NotesContext()
            : base("DefaultConnection")
        {
        }

        public static NotesContext Create()
        {
            return new NotesContext();
        }
    }
}