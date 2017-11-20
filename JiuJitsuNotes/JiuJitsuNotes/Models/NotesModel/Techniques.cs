using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace jiujitsuNotes.Models.NotesModel
{
    public enum TechniqueType
    {
        Transition, Escape, Sweep, Submission
    }
    public class Techniques
    {
        [Key]
        public int TechniqueID { get; set; }
        public string TechniqueName { get; set; }
        [ForeignKey("StartPosition")]
        public int StartPositionID { get; set; }
        public virtual Positions StartPosition { get; set; }
        [ForeignKey("EndPosition")]
        public int EndPositionID { get; set; }
        public virtual Positions EndPosition { get; set; }
        public TechniqueType TechniqueType { get; set; }
        public DateTime DateAdded { get; set; }
        public string StartingCondition { get; set; }
        public string Steps { get; set; }
        public string KeyPoints { get; set; }
        public string CommonMistakes { get; set; }


    }
}