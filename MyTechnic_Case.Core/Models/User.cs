using Microsoft.AspNetCore.Identity;

namespace MyTechnic_Case.Core.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public  DateTime Createdate { get; set; }
        public string Adress { get; set; }
        public bool isActive { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
