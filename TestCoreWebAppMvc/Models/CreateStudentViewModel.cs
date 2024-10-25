using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestCoreWebAppMvc.Models
{
    public class CreateStudentViewModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public int RollNumber { get; set; }
        public string? Image { get; set; }


        // Added a multi-select list for subjects
        public List<int>? SelectedSubjectIds { get; set; }
        public List<SelectListItem>? Subjects { get; set; }
    }
}
