using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlannerMSQL.Models
{
    
    public class MeetingModel
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MeetingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IdentityUser Owner { get; set; }
        public IList<EventModel> Events { get; set; }
        public IList<ExpenseModel> Expenses { get; set; }
    }
    public class EventModel
    {
        
        public int MeetingId { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
    }
    public class ExpenseModel
    {        
        public int MeetingId { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ExpenseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}