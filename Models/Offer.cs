using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace E_Recrutement.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        public string ContractType { get; set; }
        public string Sector { get; set; }
        public string Profile { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }


        [ForeignKey("recruiterId")]
        public int recruiterId { get; set; }

        [ValidateNever]
        public Recruiter recruiter { get; set; }
    }
}
