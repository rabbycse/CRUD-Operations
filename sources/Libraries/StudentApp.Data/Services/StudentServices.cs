using StudentApp.Data.Data;
using StudentApp.Data.Data.Entities;
using StudentApp.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StudentApp.Data.Services
{
    public class StudentServices 
         : DataServiceBase<StudentAppUnitOfWork, Student, Guid, StudentAppContext, StudentRepository>, IService
    {
        public StudentServices(StudentAppUnitOfWork uow) 
            : base(uow)
        {
        }

        public override IQueryable<Student> Read(Expression<Func<Student, bool>> filter = null)
        {
            return _Uow.Repository.Read(filter);
        }
    }
}
