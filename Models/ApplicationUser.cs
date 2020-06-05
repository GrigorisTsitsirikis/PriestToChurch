using Microsoft.AspNet.Identity.EntityFramework;

namespace MyFirstMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// email
        /// </summary>
        public virtual string Email { get; set; } // example, not necessary
    }
    }
