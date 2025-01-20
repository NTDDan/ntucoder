﻿using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS8618 // Non-nullable field
namespace api.Models.ERD
{
    public class Solved
    {
        [ForeignKey("Coder")]
        public int CoderID { get; set; }
        [ForeignKey("Problem")]
        public int ProblemID { get; set; }
        public virtual Coder Coder { get; set; }
        public virtual Problem Problem { get; set; }
    }
}
