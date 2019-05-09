using X.PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UphiweSkills.DataAccessLayer;
using UphiweSkills.Models;

namespace UphiweSkills.Controllers
{
    public class CourseController : Controller
    {
        private UnitOfWork unitOfWork;

        public CourseController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext()); 
        }
 
        // GET
        public ActionResult Courses(string currentFilter, string searchString, int? page)
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

            List<CourseViewModel> courses = new List<CourseViewModel>();

            foreach (var course in unitOfWork.Courses.GetAllCoursesByAsc((course) => course.CourseName))
            {
                courses.Add(new CourseViewModel()
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    Duration = course.Duration,
                    Level = course.Level,
                    Location = course.Location
                });
            }
            return View(courses.ToPagedList(pageNumber, pageSize));
        }

        // GET
        public ActionResult CourseDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CourseDetailsViewModel courseDetails = new CourseDetailsViewModel();
            var course = unitOfWork.Courses.GetById((int)id);
                     
            if (course == null)
            {
                return HttpNotFound();
            }
            courseDetails.Id = course.Id;
            courseDetails.CourseCode = course.CourseCode;
            courseDetails.CourseName = course.CourseName;
            courseDetails.Aim = course.Aim.Replace("{bullet}", "<br />&bull;&#09;");
            courseDetails.Accreditation = course.Accreditation;
            courseDetails.Duration = course.Duration;
            courseDetails.Level = course.Level;
            courseDetails.Location = course.Location;
            courseDetails.CourseStructure = course.CourseStructure.Replace("{bullet}", "<br />&bull;&#09;");
            courseDetails.CareerOpportunities = course.CareerOpportunities.Replace("{bullet}", "<br />&bull;&#09;");
            courseDetails.EntranceRequirements = course.EntranceRequirements.Replace("{bullet}", "<br />&bull;&#09;");
            courseDetails.HeaderImageUrl = course.HeaderImageUrl;

            return View(courseDetails);
        }
    }
}