using Microsoft.AspNetCore.Mvc;
using TestCoreWebAppMvc.Models;
using TestCoreWebAppMvc.Repository.Services.Interface;

namespace TestCoreWebAppMvc.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly ILogger<SubjectController> _logger;

        public SubjectController(ISubjectService subjectService, ILogger<SubjectController> logger)
        {
            _subjectService = subjectService;
            _logger = logger;
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subject subject)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(subject);
                }
                await _subjectService.AddAsync(subject); 
                return RedirectToAction("Create"); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating a subject: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the subject. Please try again.");
                return View(subject); 
            }
        }
    }
}