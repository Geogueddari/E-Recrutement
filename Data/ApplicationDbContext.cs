using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using E_Recrutement.Data;

namespace E_Recrutement.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recruiter>().HasData(
                new Recruiter { Id = 1, Name = "Recruiter A", Phone = "123456789", Email = "recruiterA@example.com" },
                new Recruiter { Id = 2, Name = "Recruiter B", Phone = "987654321", Email = "recruiterB@example.com" }
            );

            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 30,
                    Title = "Software Engineer",
                    Degree = "Master",
                    ExperienceYears = 5,
                    Resume = "Resume_JohnDoe.pdf"
                },
                new Candidate
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Age = 25,
                    Title = "Data Analyst",
                    Degree = "Bachelor",
                    ExperienceYears = 3,
                    Resume = "Resume_JaneSmith.pdf"
                }
            );

            modelBuilder.Entity<Offer>().HasData(
                new Offer
                {
                    Id = 1,
                    recruiterId = 1,
                    ContractType = "CDI",
                    Sector = "IT",
                    Profile = "Master",
                    Position = "Backend Developer",
                    Salary = 15000
                },
                new Offer
                {
                    Id = 2,
                    recruiterId = 2,
                    ContractType = "CDD",
                    Sector = "Finance",
                    Profile = "Bachelor",
                    Position = "Financial Analyst",
                    Salary = 12000
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
