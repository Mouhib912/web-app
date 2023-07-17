using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Evaluation
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int QuestAnimateur { get; set; }
        [Required]
        public int QuestFormation { get; set; }
        [Required]
        public int QuestCondition { get; set; }

        public DateTime DateAjout { get; set; }
        public string Description { get; set; }
        public int FormationID { get; set; }

        public Formation Formation { get; set; }

        public Evaluation() { DateAjout = DateTime.Now; }

    }
}