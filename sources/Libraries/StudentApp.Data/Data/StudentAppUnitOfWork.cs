using StudentApp.Data;
using Microsoft.EntityFrameworkCore;
using StudentApp.Data.Data.Entities;
using System;

namespace StudentApp.Data.Data  
{
    public class StudentAppUnitOfWork 
        : UnitOfWorkBase<Student, Guid, StudentAppContext, StudentRepository>
    {
        public CourseRepository Courses { get; private set; }

        public StudentAppUnitOfWork(string connectionString, string migartionAssemblyName)
            : base(connectionString, migartionAssemblyName)
        {
            Courses = (CourseRepository)Activator.CreateInstance(typeof(CourseRepository), _Context);
        }
    }
}
