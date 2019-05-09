using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace UphiweSkills.Models
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string ImageFilePath { get; set; }


    }

    public class EventDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool SignUpEnabled { get; set; }
        public string ImageFilePath { get; set; }
        [Required, Display(Name = "Name")]
        public string Name { get; set; }
        [Required, Display(Name = "Surname")]
        public string Surname { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }
        [Required, Display(Name = "Contact")]
        public string ContactNumber { get; set; }

    }

    public class AddEventViewModel
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        [DisplayName("Date/Time")]
        public string EventDateTime { get; set; }
        public string Duration { get; set; }
        public bool SignUpEnabled { get; set; }
        public EventImage EventImage { get; set; }
    }

    public class EventSignUpViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
    }
}