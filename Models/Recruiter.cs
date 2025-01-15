using System.ComponentModel.DataAnnotations;

namespace E_Recrutement.Models
{
    public class Recruiter
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
