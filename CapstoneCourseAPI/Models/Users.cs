using System.ComponentModel.DataAnnotations;

namespace CapstoneCourseAPI.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? StudentId { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
    }
}
