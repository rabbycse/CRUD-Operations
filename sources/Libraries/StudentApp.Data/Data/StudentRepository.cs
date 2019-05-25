using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using StudentApp.Data;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data.Data.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace StudentApp.Data.Data 
{
    public class StudentRepository
         : RepositoryBase<Student, Guid, StudentAppContext>
    {
        public StudentRepository(StudentAppContext context)
            : base(context)
        {
        }

        internal IQueryable<Course> Read(Expression<Func<Course, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
