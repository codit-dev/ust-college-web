using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UphiweSkills.Models;
using X.PagedList;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.IO;
using UphiweSkills;
using UphiweSkills.DataAccessLayer;

namespace UphiweSkills.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork;

        public HomeController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        // GET
        public ActionResult Index()
        {   
            CoursesEventsViewModel coursesEvents = new CoursesEventsViewModel();
            coursesEvents.Courses = new List<CourseViewModel>();
            coursesEvents.Events = new List<EventViewModel>();

            foreach (var course in unitOfWork.Courses.GetAllCoursesByAsc((course) => course.CourseName))
            {
                coursesEvents.Courses.Add(new CourseViewModel()
                {
                    Id = course.Id,
                    CourseName = course.CourseName
                });
            }

            foreach (var eventObject in unitOfWork.Events.GetLatestEvents(3)) 
            {
                coursesEvents.Events.Add(new EventViewModel()
                {
                    Id = eventObject.Id,
                    Title = eventObject.Title,
                    Month = eventObject.EventDateTime.HasValue ? eventObject.EventDateTime.Value.ToString("MMM") : "TBC",
                    Day = eventObject.EventDateTime.HasValue ? eventObject.EventDateTime.Value.Day.ToString() : "-",
                    StartTime = eventObject.EventDateTime.HasValue ? eventObject.EventDateTime.Value.ToString("HH:mm") : "-",
                    EndTime = eventObject.EventDateTime.HasValue ? eventObject.EventDateTime.Value.Add(eventObject.Duration.Value).ToString("HH:mm") : "-",
                    Location = eventObject.Location
                });
            }

            return View(coursesEvents);
        }

        // GET
        public ActionResult About()
        {
            return View();
        }

        // GET
        public ActionResult OurCourses()
        {
            return View();
        }

        // GET
        public ActionResult FAQ()
        {
            return View();
        }

        // GET
        public ActionResult Gallery()
        {
            return View();
        }

        // GET
        public ActionResult Contact()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: " + model.FromName + " (" + model.FromEmail + ")<br />Subject: " + model.Subject + "<br />Phone: " + model.FromPhoneNumber + "</p><p>Message:</p><p>" + model.Message + "</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("contact@uphiweskills.co.za"));
                message.Subject = "Web message from " + model.FromName;
                message.Body = string.Format(body);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

    }
}