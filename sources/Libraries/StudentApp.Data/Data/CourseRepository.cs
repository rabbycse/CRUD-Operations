using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using StudentApp.Data.Data.Entities;
using Microsoft.EntityFrameworkCore; 

namespace StudentApp.Data.Data 
{
    public class CourseRepository
        : RepositoryBase<Course, Guid, StudentAppContext>
    {
        public CourseRepository(StudentAppContext context)
            : base(context)
        {
        }
    }
}
