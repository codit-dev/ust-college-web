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
    public class EventController : Controller
    {
        private UnitOfWork unitOfWork;

        public EventController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        // GET
        public ActionResult Events(string currentFilter, string searchString, int? page)
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

            List<EventViewModel> events = new List<EventViewModel>();

            foreach (var eventObject in unitOfWork.Events.GetAllEventsByDesc((eventObject) => (DateTime)eventObject.EventDateTime))
            {
                events.Add(new EventViewModel()
                {
                    Id = eventObject.Id,
                    Title = eventObject.Title,
                    Month = eventObject.EventDateTime.HasValue ? eventObject.EventDateTime.Value.ToString("MMM") : "TBC",
                    Day = eventObject.EventDateTime.HasValue ? eventObject.EventDateTime.Value.Day.ToString() : "-",
                    StartTime = eventObject.EventDateTime.HasValue ? eventObject.EventDateTime.Value.ToString("HH:mm") : "-",
                    EndTime = eventObject.EventDateTime.HasValue ? eventObject.EventDateTime.Value.Add(eventObject.Duration.Value).ToString("HH:mm") : "-",
                    Location = eventObject.Location,
                    Description = eventObject.Description,
                    ImageFilePath = eventObject.EventImage.ImageFilePath
                });
            }

            return View(events.ToPagedList(pageNumber, pageSize));
        }

        // GET
        public ActionResult EventDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event eventItem = unitOfWork.Events.GetByGuid((Guid)id);

            if (eventItem == null)
            {
                return HttpNotFound();
            }

            EventDetailsViewModel eventDetails = new EventDetailsViewModel();

            eventDetails.Id = eventItem.Id;
            eventDetails.Title = eventItem.Title;
            eventDetails.Year = eventItem.EventDateTime.HasValue ? eventItem.EventDateTime.Value.ToString("yyyy") : "-";
            eventDetails.Month = eventItem.EventDateTime.HasValue ? eventItem.EventDateTime.Value.ToString("MMMM") : "-"; 
            eventDetails.Day = eventItem.EventDateTime.HasValue ? eventItem.EventDateTime.Value.Day.ToString() : "-";
            eventDetails.StartTime = eventItem.EventDateTime.HasValue ? eventItem.EventDateTime.Value.ToString("HH:mm") : "-";
            eventDetails.EndTime = eventItem.EventDateTime.HasValue ? eventItem.EventDateTime.Value.Add(eventItem.Duration.Value).ToString("HH:mm") : "-";
            eventDetails.Location = eventItem.Location;
            eventDetails.Description = eventItem.Description;
            eventDetails.ImageFilePath = eventItem.EventImage.ImageFilePath;
            eventDetails.SignUpEnabled = eventItem.SignUpEnabled;

            return View(eventDetails);
        }

        // GET: EventSignUps
        // TODO this controller needs fixing with its view
        public ActionResult EventSignUps(string currentFilter, string searchString, int? page, Guid id)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            // Fetches an event of specified id and its related sign ups
            var eventObject = unitOfWork.Events.GetEventWithSignUps(id);

            // Assigns event title to sign up view bag
            ViewBag.EventTitle = eventObject.Title;

            // Initializes eventSignUps List
             List<EventSignUpViewModel> eventSignUps = new List<EventSignUpViewModel>();

            if (eventObject.EventSignUps.Count != 0)
            {
                foreach (var eventSignUp in eventObject.EventSignUps)
                {
                    // Adds newly created instance of EventSignUpViewModel to event sign-ups
                    eventSignUps.Add(new EventSignUpViewModel()
                        {
                            Id = eventSignUp.Id,
                            Name = eventSignUp.Name,
                            Surname = eventSignUp.Surname,
                            Email = eventSignUp.Email,
                            ContactNumber = eventSignUp.ContactNumber   
                            
                        }
                    );
                }
                // Convert List to PagedList and pass to view
                return View(eventSignUps.ToPagedList(pageNumber, pageSize));
            }
            // Converts List back to PagedList
            return View(eventSignUps.ToPagedList(pageNumber, pageSize)); //TODO add alert message to view to notify user that there are no events
        }

        // POST: /Event/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEvent(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event eventItem = unitOfWork.Events.GetByGuid((Guid)id);

            if (eventItem == null)
            {
                return HttpNotFound();
            }

            // Deletes event image if it was added
            if (System.IO.File.Exists(Server.MapPath(eventItem.EventImage.ImageFilePath)) && eventItem.EventImage.ImageFilePath != "/Content/Images/EventImages/no-image-available.png")
            {
                System.IO.File.Delete(Server.MapPath(eventItem.EventImage.ImageFilePath));
            }

            unitOfWork.Events.Remove(eventItem);
            unitOfWork.SaveChanges();
            return RedirectToAction("Events");
        }

        // POST
        [HttpPost]
        //TODO [ValidateAntiForgeryToken] (Also move modal to partial view to allow validation
        //TODO Add client side validation to all forms and fix button alignment and event image allignment
        public async Task<ActionResult> EventSignUp(Guid? id, EventDetailsViewModel model)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                EventSignUp eventSignUp = new EventSignUp()
                {
                    EventId = (Guid)id,
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    ContactNumber = model.ContactNumber
                    
                };

                unitOfWork.EventSignUps.Add(eventSignUp);
                unitOfWork.SaveChanges();

                Event eventItem = unitOfWork.Events.GetByGuid((Guid)id);

                var body = "<p>" + model.Name + " " + model.Surname + " has signed up for " + "\"" + eventItem.Title + "\"" + ".<br />This person can be be contacted on " + model.Email + " or " + model;
                var message = new MailMessage();
                message.To.Add(new MailAddress("freeworkshop@uphiweskills.co.za"));
                message.Subject = model.Name + " has signed up!";
                message.Body = string.Format(body, model.Name, model.Surname, model.Email, model.ContactNumber, eventItem.Title);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                }
            }
            
            // TODO: add else statement that returns model to current view (sign up form)

            return RedirectToAction("EventDetails", new { id = id });
        }

        // GET
        public ActionResult AddEvent()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult AddEvent([Bind(Include = "Id,Title,Description,Location,EventDateTime,Duration,SignUpEnabled,ImageFilePath")] AddEventViewModel eventModel)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase eventImage = Request.Files["EventImage"];

                Event newEvent = new Event();

                newEvent.Id = Guid.NewGuid();
                newEvent.Title = eventModel.Title;
                newEvent.Description = eventModel.Description;
                newEvent.Location = eventModel.Location;
        
                if (string.IsNullOrEmpty(eventModel.EventDateTime) || string.IsNullOrEmpty(eventModel.Duration))
                {
                    newEvent.EventDateTime = null; 
                    newEvent.Duration = null; 
                }
                else
                {
                    newEvent.EventDateTime = DateTime.ParseExact(eventModel.EventDateTime, "d/MMM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    newEvent.Duration = TimeSpan.Parse(eventModel.Duration);
                }
                newEvent.SignUpEnabled = eventModel.SignUpEnabled;

                unitOfWork.Events.Add(newEvent);
                unitOfWork.SaveChanges();

                //Adds image if eventImage isn't null
                if (eventImage != null && eventImage.ContentLength > 0 && newEvent.EventDateTime.HasValue && newEvent.Duration.HasValue)
                {
                    var imageFilePath = Server.MapPath("~/Content/Images/EventImages/" + newEvent.EventDateTime.Value.Year + "/" + newEvent.EventDateTime.Value.Month);

                    if (!Directory.Exists(imageFilePath))
                    {
                        Directory.CreateDirectory(imageFilePath);
                    }

                    eventImage.SaveAs(Path.Combine(imageFilePath, newEvent.Id.ToString() + Helpers.AddImageExtension(eventImage.ContentType)));

                    unitOfWork.EventImages.Add(new EventImage
                    {
                        Id = newEvent.Id,
                        ImageFilePath = "/Content/Images/EventImages/" + newEvent.EventDateTime.Value.Year + "/" + newEvent.EventDateTime.Value.Month + "/" + newEvent.Id + Helpers.AddImageExtension(eventImage.ContentType)
                    });

                    unitOfWork.SaveChanges();
                }
                else
                {
                    unitOfWork.EventImages.Add(new EventImage
                    {
                        Id = newEvent.Id,
                        ImageFilePath = "/Content/Images/EventImages/no-image-available.png"
                    });

                    unitOfWork.SaveChanges();
                }


                return RedirectToAction("Events");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            return View(eventModel);
        }

        // POST: /Event/Delete/
        [HttpPost]
        //TODO add [ValidateAntiForgeryToken] here
        public ActionResult SetSignUpEnabled([Bind(Include = "SignUpEnabled")] Guid? id, EventDetailsViewModel model)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            unitOfWork.Events.GetByGuid((Guid)id).SignUpEnabled = model.SignUpEnabled;
            unitOfWork.SaveChanges();

            return RedirectToAction("EventDetails", new { id = id });
        }

        // GET:
        [ChildActionOnly]
        //[ValidateAntiForgeryToken()]
        public ActionResult _EventSignUpForm(EventDetailsViewModel model)
        {
            if (model.SignUpEnabled)
            {
                if (!Request.IsAuthenticated)
                {
                    ModelState.Clear();
                    return PartialView(model);
                }

            }

            return new EmptyResult();
        }
    }
}