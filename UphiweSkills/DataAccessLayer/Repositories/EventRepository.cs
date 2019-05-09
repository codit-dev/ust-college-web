using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using UphiweSkills.DataAccessLayer.IRepositories;
using UphiweSkills.Models;

namespace UphiweSkills.DataAccessLayer.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Event> GetLatestEvents(int count)
        {
            return ApplicationDbContext.Events
                .OrderByDescending(e => e.EventDateTime)
                .Take(count)
                .ToList();
        }

        public IEnumerable<Event> GetAllEventsByDesc(Expression<Func<Event, DateTime>> keySelector)
        {
            return ApplicationDbContext.Events
                .OrderByDescending(keySelector)
                .ToList();
        }

        public Event GetEventWithSignUps(Guid id)
        {
            return ApplicationDbContext.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventSignUps)
                .FirstOrDefault();
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }

}