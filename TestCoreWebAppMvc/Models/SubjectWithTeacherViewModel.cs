namespace TestCoreWebAppMvc.Models
{
    public class SubjectWithTeacherViewModel
    {

        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public List<string> Teachers { get; set; } // List to hold multiple teachers
    }
   
}
