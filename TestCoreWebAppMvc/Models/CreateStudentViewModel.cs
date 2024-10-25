using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TestCoreWebAppMvc.Models
{
    public class CreateStudentViewModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int Age { get; set; }
        public string Class { get; set; }
        [Required(ErrorMessage = "RollNumber is required.")]
        public int RollNumber { get; set; }
        public string? Image { get; set; }


        // Added a multi-select list for subjects
        public List<int>? SelectedSubjectIds { get; set; }
        public List<SelectListItem>? Subjects { get; set; }
    }
}
