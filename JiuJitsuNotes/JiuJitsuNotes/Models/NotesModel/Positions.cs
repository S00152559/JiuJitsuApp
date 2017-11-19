using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace jiujitsuNotes.Models.NotesModel
{
    public class Positions
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public virtual ICollection<Techniques> Techniques { get; set; }
    }
}