using System.ComponentModel.DataAnnotations;

namespace CandidateApi.Models
{
    public class Candidate
    {
        public int Id { get; set; }               // Primary Key

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }          // Unique Identifier

        public string TimeIntervalToCall { get; set; }

        public string LinkedInProfile { get; set; }

        public string GitHubProfile { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        public string Comment { get; set; }
    }
}
