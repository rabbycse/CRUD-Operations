using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using StudentApp.Data;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data.Data.Entities;

namespace StudentApp.Data.Data 
{
    public class CourseTopicRepository 
        : RepositoryBase<CourseTopic, Guid, StudentAppContext>
    {
        public CourseTopicRepository(StudentAppContext context) 
            : base(context)
        {
        }
    }
}
