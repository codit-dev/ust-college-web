using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using UphiweSkills.Models;

namespace UphiweSkills.DataAccessLayer.IRepositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetAllCoursesByAsc(Expression<Func<Course, string>> keySelector);
    }
}