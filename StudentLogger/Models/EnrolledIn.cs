using System;
using System.Collections.Generic;

namespace StudentLogger.Models
{
    public partial class EnrolledIn
    {
        public int EnrollId { get; set; }
        public int? CourseId { get; set; }
        public int? StudentId { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Students Student { get; set; }
    }
}
