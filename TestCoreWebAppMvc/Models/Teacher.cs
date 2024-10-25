using System.ComponentModel.DataAnnotations;

namespace TestCoreWebAppMvc.Models
{
	public class Teacher
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string? Image { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Sex is required.")]
        public string Sex { get; set; }
        // Relationships
        public ICollection<TeacherSubject>? TeacherSubjects { get; set; }
    }

}
