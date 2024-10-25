namespace TestCoreWebAppMvc.Models
{
    public class TeacherSubject
    {
        public int TeacherSubjectId { get; set; } // Primary Key
        public int TeacherId { get; set; } // Foreign Key
        public Teacher Teacher { get; set; }

        public int SubjectId { get; set; } // Foreign Key
        public Subject Subject { get; set; }
        public string ClassName { get; set; }

    }
}
