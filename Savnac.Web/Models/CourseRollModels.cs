using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Savnac.Web.Models
{
    
    public class CourseRollContext : DbContext
    {
        public CourseRollContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<CourseRoll> CourseRolls { get; set; }
    }

    [Table("CourseRoll")]
    public class CourseRoll
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CourseRollId { get; set; }

        /// This is where we will add the members to store data for a courseroll
        /// ex. 
        /// list<T> listofstudents
        /// int CourseId
        /// 
    }
    
    
    
}