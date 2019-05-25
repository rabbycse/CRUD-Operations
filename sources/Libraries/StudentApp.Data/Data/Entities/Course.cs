using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentApp.Data.Data.Entities
{
    public class Course
         : EntityBase<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public ICollection<CourseTopic> Topics { get; set; } = new List<CourseTopic>();

        public virtual ICollection<StudentCourses> CourseStudents { get; set; } = new List<StudentCourses>();
    }
} 
 