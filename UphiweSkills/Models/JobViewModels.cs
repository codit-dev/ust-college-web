using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace UphiweSkills.Models
{
    public class JobVacancySnippetViewModel
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string JobDescriptionSnippet { get; set; }
        public string EmploymentType { get; set; }
        public string EmpTypeClasses { get; set; }
        public string DatePosted { get; set; } 
    }
}