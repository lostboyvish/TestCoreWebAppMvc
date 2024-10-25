using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TestCoreWebAppMvc.Models
{
    public class TeacherViewModel
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the teacher's age.")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int Age { get; set; }
        [Required]
        public string Sex { get; set; }
        public string? Image { get; set; }
        public List<SelectListItem>? Subjects { get; set; } // For subject selection
        public List<string> Teachers { get; set; }
        public List<int> SelectedSubjectIds { get; set; } // For selected subjects
    }
}
