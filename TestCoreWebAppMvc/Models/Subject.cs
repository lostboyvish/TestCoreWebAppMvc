using System.ComponentModel.DataAnnotations;

namespace TestCoreWebAppMvc.Models
{
	public class Subject
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Class is required.")]
        public string Class { get; set; }
        public string Language { get; set; }
        // Relationships
        public ICollection<StudentSubject>? StudentSubjects { get; set; }
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }

    }

}
