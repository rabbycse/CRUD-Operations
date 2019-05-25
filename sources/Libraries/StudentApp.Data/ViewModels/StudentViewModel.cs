using StudentApp.Data;
using StudentApp.Data.Data;
using StudentApp.Data.Data.Entities;
using StudentApp.Data.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace StudentApp.Data.ViewModels 
{
    public class StudentViewModel
        : ViewModelBase<StudentServices, StudentAppUnitOfWork, Student, Guid, StudentAppContext, StudentRepository>
    {
        [Required]
        public string Name { get; set; }

        public override void Read(Expression<Func<Student, bool>> filter = null)
        {
            var studentQuery = _Service.Read(filter);
            Name = studentQuery.First().Name;
        }
    }
}
