using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TestCoreWebAppMvc.Models;
using TestCoreWebAppMvc.Repository.Services.Implementation;
using TestCoreWebAppMvc.Repository.Services.Interface;

namespace TestCoreWebAppMvc.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ILogger<TeacherController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TeacherController(ITeacherService teacherService, ILogger<TeacherController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _teacherService = teacherService;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: Teacher/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {



            try
            {
                var subjects = await _teacherService.GetAllSubjectsAsync();
                var viewModel = new TeacherViewModel
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
                return View(ex); // Return the view with an error message
            }

        }

        // POST: Teacher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherViewModel viewModel, IFormFile imageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _teacherService.AddAsync(viewModel);
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Path.GetFileName(imageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/TeacherImages/", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(fileStream);
                        }
                        viewModel.Image = fileName;
                        var teacher = new Teacher
                        {
                            Name = viewModel.Name,
                            Image = viewModel.Image,
                            Sex = viewModel.Sex,
                            Age = viewModel.Age,
                        };
                        await _teacherService.UpdateAsync(teacher);
                    }

                    return RedirectToAction("Create");
                }
                viewModel.Subjects = (await _teacherService.GetAllSubjectsAsync())

                   .Select(s => new SelectListItem
                   {
                       Value = s.Id.ToString(),
                       Text = s.Name
                   }).ToList();


                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating a teacher: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the teacher. Please try again.");
                return View(viewModel);
            }
        }
    }
}
