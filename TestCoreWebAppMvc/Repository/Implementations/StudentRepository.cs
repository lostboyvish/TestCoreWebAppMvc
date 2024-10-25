using TestCoreWebAppMvc.Data;
using TestCoreWebAppMvc.Models;
using TestCoreWebAppMvc.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace TestCoreWebAppMvc.Repository.Implementations
{
	public class StudentRepository : IStudentRepository
	{
		private readonly ApplicationDbContext _context;

		public StudentRepository(ApplicationDbContext context)
		{
			_context = context;
		}
        public async Task<IEnumerable<SubjectWithTeacherViewModel>> GetSubjectsForStudentsAsync()
        {
            return await _context.StudentSubjects
        .Include(ss => ss.Student)
        .Include(ss => ss.Subject)
        .ThenInclude(s => s.TeacherSubjects)
        .ThenInclude(ts => ts.Teacher)
        .Select(ss => new SubjectWithTeacherViewModel
        {
            StudentName = ss.Student.Name,
            SubjectName = ss.Subject.Name,
            Teachers = ss.Subject.TeacherSubjects
                .Select(ts => ts.Teacher.Name) // Selecting teacher names as strings
                .ToList() // Convert to list of strings
        })
        .ToListAsync();
        }
        public async Task AddStudentSubjectAsync(StudentSubject studentSubject)
        {
            _context.StudentSubjects.Add(studentSubject);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<string>> GetAllClassesAsync()
        {
            // Fetch distinct class names from the students table
            return await _context.Students
                                 .Select(s => s.Class)
                                 .Distinct()
                                 .ToListAsync();
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
		{
			return await _context.Students.ToListAsync();
		}

		

		public async Task AddStudentAsync(Student student)
		{
			_context.Students.Add(student);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateStudentAsync(Student student)
		{
			_context.Students.Update(student);
			await _context.SaveChangesAsync();
		}
        public async Task<IEnumerable<Student>> GetStudentsByClassAsync(string className)
        {
            return await _context.Students
                .Where(s => s.Class == className)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> SearchStudentsByNameAsync(string searchTerm)
        {
            return await _context.Students
                .Where(s => s.Name.Contains(searchTerm))
                .ToListAsync();
        }
        
	}
}