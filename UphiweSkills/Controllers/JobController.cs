using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UphiweSkills.DataAccessLayer;
using UphiweSkills.Models;
using X.PagedList;

namespace UphiweSkills.Controllers
{
    public class JobController : Controller
    {
        private UnitOfWork unitOfWork;

        public JobController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: Job Vacancies
        public ActionResult JobVacanies(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            List<JobVacancySnippetViewModel> jobVacancySnippets = new List<JobVacancySnippetViewModel>();

            foreach (var jobVacancy in unitOfWork.JobVacancies.GetAll().OrderByDescending(vacancy => vacancy.DatePosted))
            {
                jobVacancySnippets.Add(new JobVacancySnippetViewModel()
                {
                    Id = jobVacancy.Id,
                    JobTitle = jobVacancy.JobTitle,
                    JobDescriptionSnippet = jobVacancy.JobDescriptionSnippet,
                    Department = jobVacancy.Department,
                    EmploymentType = jobVacancy.EmploymentType,
                    EmpTypeClasses = jobVacancy.EmpTypeClasses,
                    DatePosted = jobVacancy.DatePosted.Month.ToString("MMMM") + " " + jobVacancy.DatePosted.Day.ToString("d") + ", " + jobVacancy.DatePosted.Year.ToString("yyyy"),
                    Location = jobVacancy.Location,
                    Salary = jobVacancy.Salary
                });
            }

            return View(jobVacancySnippets.ToPagedList(pageNumber, pageSize));
        }

        // GET: Job Vacancy
        public ActionResult JobVacancy()
        {
            return View();
        }
    }
}