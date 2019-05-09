using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace UphiweSkills.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public string Duration { get; set; }
        public string Level { get; set; }
    }

    public class CourseDetailsViewModel
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Aim { get; set; }
        public string Accreditation { get; set; }
        public string CourseStructure { get; set; }
        public string EntranceRequirements { get; set; }
        public string Location { get; set; }
        public string CareerOpportunities { get; set; }
        public string Duration { get; set; }
        public string Level { get; set; }
        public string HeaderImageUrl { get; set; }
    }
}