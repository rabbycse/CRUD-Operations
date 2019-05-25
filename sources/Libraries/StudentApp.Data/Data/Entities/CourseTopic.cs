using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentApp.Data.Data.Entities
{
    public class CourseTopic 
        : EntityBase<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual Course Course { get; set; }
        public Guid CourseId { get; set; }
    }
}
