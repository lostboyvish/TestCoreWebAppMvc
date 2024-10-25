using System.ComponentModel.DataAnnotations;

namespace TestCoreWebAppMvc.Models
{
	public class Student
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public int Age { get; set; }
		public string? Image { get; set; }
		public string Class { get; set; }
		[Required]
		public int RollNumber { get; set; }
        // Relationships
        public ICollection<StudentSubject>? StudentSubjects { get; set; }

    }

}
