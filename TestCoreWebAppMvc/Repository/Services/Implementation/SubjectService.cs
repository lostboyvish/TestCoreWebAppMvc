using TestCoreWebAppMvc.Models;
using TestCoreWebAppMvc.Repository.Implementations;
using TestCoreWebAppMvc.Repository.Interface;
using TestCoreWebAppMvc.Repository.Services.Interface;

namespace TestCoreWebAppMvc.Repository.Services.Implementation
{
    public class SubjectService:ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        

        
      
        public async Task AddAsync(Subject subject)
        {
            await _subjectRepository.AddAsync(subject);
        }

        

        
    }
}
