using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using UphiweSkills.Models;

namespace UphiweSkills.DataAccessLayer.IRepositories
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetLatestEvents(int count);
        Event GetEventWithSignUps(Guid id);
        IEnumerable<Event> GetAllEventsByDesc(Expression<Func<Event, DateTime>> keySelector);
    }
}