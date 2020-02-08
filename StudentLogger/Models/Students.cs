using System;
using System.Collections.Generic;

namespace StudentLogger.Models
{
    public partial class Students
    {
        public Students()
        {
            Activities = new HashSet<Activities>();
            EnrolledIn = new HashSet<EnrolledIn>();
        }

        public int StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime? EnrollDate { get; set; }

        public virtual ICollection<Activities> Activities { get; set; }
        public virtual ICollection<EnrolledIn> EnrolledIn { get; set; }
    }
}
