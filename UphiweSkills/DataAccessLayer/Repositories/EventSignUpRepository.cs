using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UphiweSkills.DataAccessLayer.IRepositories;
using UphiweSkills.Models;

namespace UphiweSkills.DataAccessLayer.Repositories
{
    public class EventSignUpRepository : Repository<EventSignUp>, IEventSignUpRepository
    {
        public EventSignUpRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }

}