using TestCoreWebAppMvc.Models;

namespace TestCoreWebAppMvc.Repository.Services.Interface
{
	public interface IStudentService
	{
		Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<Student>> GetStudentsByClassAsync(string className);
        Task<IEnumerable<Student>> SearchStudentsByNameAsync(string searchTerm);
		Task UpdateStudentAsync(Student student);
		Task<IEnumerable<string>> GetAllClassesAsync();
        Task AddStudentAsync(CreateStudentViewModel viewModel);
		 Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<IEnumerable<SubjectWithTeacherViewModel>> GetSubjectsForStudentsAsync();

    }

}
