using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModel
{
    public class RegistrationViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
