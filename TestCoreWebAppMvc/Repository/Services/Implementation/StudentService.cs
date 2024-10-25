using Microsoft.EntityFrameworkCore;
using TestCoreWebAppMvc.Models;
using TestCoreWebAppMvc.Repository.Interface;
using TestCoreWebAppMvc.Repository.Services.Interface;

namespace TestCoreWebAppMvc.Repository.Services.Implementation
{
	public class StudentService : IStudentService
	{
		private readonly IStudentRepository _studentRepository;
		private readonly ISubjectRepository _subjectRepository;

		// Inject the repository using Dependency Injection
		public StudentService(IStudentRepository studentRepository,ISubjectRepository subjectRepository)
		{
			_studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
		}
        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _subjectRepository.GetAllSubjectsAsync();
        }
        public async Task<IEnumerable<SubjectWithTeacherViewModel>> GetSubjectsForStudentsAsync()
        {
            return await _studentRepository.GetSubjectsForStudentsAsync();
        }
        public async Task AddStudentAsync(CreateStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Age = viewModel.Age,
                Class = viewModel.Class,
                RollNumber = viewModel.RollNumber
            };

            await _studentRepository.AddStudentAsync(student);

            if (viewModel.SelectedSubjectIds != null)
            {
                foreach (var subjectId in viewModel.SelectedSubjectIds)
                {
                    var studentSubject = new StudentSubject
                    {
                        StudentId = student.Id,
                        SubjectId = subjectId
                    };

                    await _studentRepository.AddStudentSubjectAsync(studentSubject);
                }
            }
        }
        
        public async Task<IEnumerable<string>> GetAllClassesAsync()
        {
            return await _studentRepository.GetAllClassesAsync(); // Fetch the distinct class names
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
		{
			return await _studentRepository.GetAllStudentsAsync();
		}

        public async Task<IEnumerable<Student>> GetStudentsByClassAsync(string className)
        {
            return await _studentRepository.GetStudentsByClassAsync(className);
        }

        public async Task<IEnumerable<Student>> SearchStudentsByNameAsync(string searchTerm)
        {
            return await _studentRepository.SearchStudentsByNameAsync(searchTerm);
        }
        public async Task UpdateStudentAsync(Student student)
		{
			await _studentRepository.UpdateStudentAsync(student);
		}

		
	}
}
