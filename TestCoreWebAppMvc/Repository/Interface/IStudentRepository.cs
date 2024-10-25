using TestCoreWebAppMvc.Models;

namespace TestCoreWebAppMvc.Repository.Interface
{
	public interface IStudentRepository
	{
		Task<IEnumerable<Student>> GetAllStudentsAsync();
		Task AddStudentAsync(Student student);
		Task UpdateStudentAsync(Student student);
        Task<IEnumerable<Student>> GetStudentsByClassAsync(string className);
        Task<IEnumerable<Student>> SearchStudentsByNameAsync(string searchTerm);
        Task<IEnumerable<string>> GetAllClassesAsync();
        Task AddStudentSubjectAsync(StudentSubject studentSubject);
        Task<IEnumerable<SubjectWithTeacherViewModel>> GetSubjectsForStudentsAsync();
    }
}
