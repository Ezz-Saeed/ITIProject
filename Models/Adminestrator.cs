using Microsoft.AspNetCore.Mvc;

namespace ITIProject.Models
{
    public class Adminestrator
    {
        //public int Id { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        [Remote("VallidateAdminIdentity", "Admin", ErrorMessage = "Wrong user name or password.", AdditionalFields = "Name")]
        public string Password { get; set; }
    }
}
