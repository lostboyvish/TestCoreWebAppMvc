using System.ComponentModel.DataAnnotations;

namespace TestCoreWebAppMvc.Models
{
    public class StudentSubject
    {
        public int StudentSubjectId { get; set; } // Primary Key
        public int StudentId { get; set; } // Foreign Key
        public Student Student { get; set; }

        public int SubjectId { get; set; } // Foreign Key
        public Subject? Subject { get; set; }

    }
}
