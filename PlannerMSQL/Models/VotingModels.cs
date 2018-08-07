using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlannerMSQL.Models
{
    public class Voting
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VotingId { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean IsOpenQuestion { get; set; }
    }
    public class VotingAnswer
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VotingAnswerId { get; set; }
        [ForeignKey("Voting")]
        public int VotingId { get; set; }
        public virtual Voting Voting { get; set; }
        public string AnswerText { get; set; }
    }
    
    public class Vote
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int VoteId { get; set; }
        [ForeignKey("Voting")]
        public int? VotingId { get; set; }
        public virtual Voting Voting { get; set; }
        public string OpenAnswer { get; set; }
        [ForeignKey("VotingAnswer")]
        public int VotingAnswerId { get; set; }
        public virtual VotingAnswer VotingAnswer { get; set; }
    }

    
}