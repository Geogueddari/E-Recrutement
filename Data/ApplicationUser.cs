using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace E_Recrutement.Data
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        public string UserName { get; set; }
    }
}
