using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UphiweSkills.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class Event
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Description { get; set; } 
        public DateTime? EventDateTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public bool SignUpEnabled { get; set; }
        public virtual EventImage EventImage { get; set; }
        public ICollection<EventSignUp> EventSignUps { get; set; }
    }

    public class EventImage
    {
        public Guid Id { get; set; }
        public string ImageFilePath { get; set; }
        public virtual Event Event { get; set; }
    }

    public class EventSignUp
    {
        public int Id { get; set; }
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public Event RelatedEvent { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Aim { get; set; }
        public string Accreditation { get; set; }
        public string CourseStructure { get; set; }
        public string EntranceRequirements { get; set;}
        public string Location { get; set; }
        public string CareerOpportunities { get; set; }
        public string Duration { get; set; }
        public string Level { get; set; }
        public string HeaderImageUrl { get; set; }
    }

    public class JobVacancy
    {
        public int Id { get; set; }
        public string JobReference { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string JobDescriptionSnippet { get; set; }
        public string EmploymentType { get; set; }
        public string EmpTypeClasses { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsOpen { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventImage> EventImages { get; set; }
        public DbSet<EventSignUp> EventSignUps { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<JobVacancy> JobVacancies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>()
                .HasOptional(e => e.EventImage)
                .WithRequired(em => em.Event)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<EventSignUp>()
                .HasRequired<Event>(es => es.RelatedEvent)
                .WithMany(e => e.EventSignUps)
                .HasForeignKey<Guid>(es => es.EventId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}