using System;
using System.Collections.Generic;

namespace StudentLogger.Models
{
    public partial class Courses
    {
        public Courses()
        {
            Activities = new HashSet<Activities>();
            EnrolledIn = new HashSet<EnrolledIn>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Proffesor { get; set; }

        public virtual ICollection<Activities> Activities { get; set; }
        public virtual ICollection<EnrolledIn> EnrolledIn { get; set; }
    }
}
