using System;
using System.Collections.Generic;

namespace StudentLogger.Models
{
    public partial class Activities
    {
        public int ActivityId { get; set; }
        public int? CourseId { get; set; }
        public int? StudentId { get; set; }
        public string ActivitiesType { get; set; }
        public DateTime? DatePresented { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Students Student { get; set; }
    }
}
