using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UphiweSkills.DataAccessLayer.IRepositories;
using UphiweSkills.DataAccessLayer.Repositories;
using UphiweSkills.Models;

namespace UphiweSkills.DataAccessLayer
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Events = new EventRepository(_context);
            EventSignUps = new EventSignUpRepository(_context);
            EventImages = new EventImageRepository(_context);
            JobVacancies = new JobVacancyRepository(_context);

        }

        public ICourseRepository Courses { get; private set; }
        public IEventRepository Events { get; private set; }
        public IEventSignUpRepository EventSignUps { get; private set; }
        public IEventImageRepository EventImages { get; private set; }
        public IJobVacancyRepository JobVacancies { get; private set; }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}