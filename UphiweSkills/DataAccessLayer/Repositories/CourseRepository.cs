using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using UphiweSkills.DataAccessLayer.IRepositories;
using UphiweSkills.Models;

namespace UphiweSkills.DataAccessLayer.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Course> GetAllCoursesByAsc(Expression<Func<Course, string>> keySelector)
        {
            return ApplicationDbContext.Courses
                .OrderBy(keySelector)
                .ToList();
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    
    }
}