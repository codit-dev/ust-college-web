using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UphiweSkills.DataAccessLayer.IRepositories;

namespace UphiweSkills.DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IEventRepository Events { get; }
        IEventSignUpRepository EventSignUps { get; }
        IEventImageRepository EventImages { get; }
        IJobVacancyRepository JobVacancies { get; }

        int SaveChanges();
    }
}
