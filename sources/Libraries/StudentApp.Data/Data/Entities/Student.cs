using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentApp.Data.Data.Entities
{
    public class Student
        : EntityBase<Guid>
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<StudentCourses> StudentCourses { get; set; } = new List<StudentCourses>();
    }
}
