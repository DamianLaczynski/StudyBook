using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyBook.API.Entities;
using StudyBook.API.Models;
using StudyBookAPI.Exceptions;

namespace StudyBook.API.Services
{
    public interface ISubjectService
    {
        IEnumerable<SubjectResponse> GetSubjects();
        SubjectResponse GetSubjectById(int id);
        int CreateSubject(SubjectRequest subject);
        void UpdateSubject(int id, UpdateSubjectRequest subject);
        void DeleteSubject(int id);
    }

    public class SubjectService : ISubjectService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<SubjectService> _logger;
        private readonly IMapper _mapper;

        public SubjectService(AppDbContext appDbContext, ILogger<SubjectService> logger, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public int CreateSubject(SubjectRequest subjectRequest)
        {
            var subject = _mapper.Map<Subject>(subjectRequest);
            _appDbContext.Add(subject);
            _appDbContext.SaveChanges();

            return subject.Id;
        }

        public void DeleteSubject(int id)
        {
            _logger.LogInformation($"DELETE action invoked on subject with id: {id}");

            var subject = _appDbContext.Subjects.FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                throw new NotFoundException("Subject not found");
            }

            _appDbContext.SaveChanges();
        }

        public SubjectResponse GetSubjectById(int id)
        {
            var subject = _appDbContext.Subjects
                            .Include(r => r.Tests)
                            .Include(r => r.FlashcardSets)
                            .FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                throw new NotFoundException("Subject not found");
            }

            var result = _mapper.Map<SubjectResponse>(subject);

            return result;
        }

        public IEnumerable<SubjectResponse> GetSubjects()
        {
            var subjects = _appDbContext.Subjects.Include(s => s.Tests).Include(s => s.FlashcardSets).ToList();

            var result = _mapper.Map<IEnumerable<SubjectResponse>>(subjects);

            return result;
        }

        public void UpdateSubject(int id, UpdateSubjectRequest updateSubjectRequest)
        {
            var subjectToUpdate = _appDbContext.Subjects.FirstOrDefault(s => s.Id == id);

            if (subjectToUpdate == null)
            {
                throw new NotFoundException("Subject not found");
            }

            subjectToUpdate.Name = updateSubjectRequest.Name != null ? updateSubjectRequest.Name : subjectToUpdate.Name;
            subjectToUpdate.Description = updateSubjectRequest.Description != null ? updateSubjectRequest.Description : subjectToUpdate.Description;

            _appDbContext.SaveChanges();
        }
    }
}