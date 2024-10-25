using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestCoreWebAppMvc.Models;
using TestCoreWebAppMvc.Repository.Services.Interface;

namespace TestCoreWebAppMvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<StudentController> _logger;
        public StudentController(IStudentService studentService, IWebHostEnvironment webHostEnvironment, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // Fetch distinct class names from the database
                var classes = await _studentService.GetAllClassesAsync();
                ViewBag.ClassList = new SelectList(classes);

                // Fetch all students initially
                var students = await _studentService.GetAllStudentsAsync();
                return View(students);
            }
            catch (Exception ex)
            {

                _logger.LogError($"An error occurred while creating a subject: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the subject. Please try again.");
            return View(ex);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Index(string className, string searchString)
        {
            try
            {
                IEnumerable<Student> students;
                // Fetch distinct class names from the database
                var classes = await _studentService.GetAllClassesAsync();
                ViewBag.ClassList = new SelectList(classes);
                if (!string.IsNullOrEmpty(searchString))
                {
                    // Search students by name
                    students = await _studentService.SearchStudentsByNameAsync(searchString);
                }
                else if (!string.IsNullOrEmpty(className))
                {
                    // Get students class-wise
                    students = await _studentService.GetStudentsByClassAsync(className);
                }
                else
                {
                    // Get all students if no filter is applied
                    students = await _studentService.GetAllStudentsAsync();
                }

                return View(students);
            }
            catch (Exception ex)
            {

                _logger.LogError($"An error occurred while creating a subject: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the subject. Please try again.");
                return View(ex); 

            }

        }

        // GET: Student/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var subjects = await _studentService.GetAllSubjectsAsync();
                var viewModel = new CreateStudentViewModel
                {
                    Subjects = subjects.Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name
                    }).ToList()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {

                _logger.LogError($"An error occurred while creating a subject: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the subject. Please try again.");
                return View(ex); 
            }
            

        }

        // POST: Adding Students
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudentViewModel viewModel, IFormFile imageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _studentService.AddStudentAsync(viewModel);

                    if (imageFile != null && imageFile.Length > 0)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName =  Path.GetFileName(imageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/images/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(fileStream);
                        }
                        viewModel.Image = fileName;
                        var student = new Student
                        {
                            Name = viewModel.Name,
                            Age = viewModel.Age,
                            Class = viewModel.Class,
                            RollNumber = viewModel.RollNumber,
                            Image = viewModel.Image 
                        };
                        await _studentService.UpdateStudentAsync(student);
                    }
                    return RedirectToAction("Create");
                }
                viewModel.Subjects = (await _studentService.GetAllSubjectsAsync())
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name
                    }).ToList();

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating a subject: {ex.Message}");
                ModelState.AddModelError("", "An error occurred while saving the student.");
                return View(viewModel);
            }
        }

        public async Task<IActionResult> SubjectsForStudents()
        {
            try
            {
                var model = await _studentService.GetSubjectsForStudentsAsync();
                return View(model);
            }
            catch (Exception ex)
            {

                _logger.LogError($"An error occurred while creating a subject: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the subject. Please try again.");
                return View(ex); 
            }
           
        }
    }
}
