using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    }

}
