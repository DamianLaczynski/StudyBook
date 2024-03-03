using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyBook.API.Entities;
using StudyBook.API.Models;
using StudyBookAPI.Exceptions;

namespace StudyBook.API.Services
{
    public interface ITestService
    {
        TestResponse GetTest(int subjectId, int id);
        IEnumerable<TestResponse> GetTests(int subjectId);
        int CreateTest(int subjectId, TestRequest testRequest);
        void UpdateTest(int subjectId, int id, TestRequest testRequest);
        void DeleteTest(int subjectId, int id);
    }
    public class TestService : ITestService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<TestService> _logger;
        private readonly IMapper _mapper;

        public TestService(AppDbContext appDbContext, ILogger<TestService> logger, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public int CreateTest(int subjectId, TestRequest testRequest)
        {
            var test = _mapper.Map<Test>(testRequest);
            test.SubjectId = subjectId;

            _appDbContext.Add(test);

            _appDbContext.SaveChanges();

            return test.Id;
        }

        public void DeleteTest(int subjectId, int id)
        {
            _logger.LogInformation($"DELETE action invoked on test with id {id} for subject {subjectId}");

            var test = _appDbContext.Tests
                .Where(t => t.SubjectId == subjectId)
                .FirstOrDefault(t => t.Id == id);

            if(test == null)
            {
                throw new NotFoundException("Test not found");
            }

            _appDbContext.Tests.Remove(test);
            _appDbContext.SaveChanges();
        }

        public TestResponse GetTest(int subjectId, int id)
        {
            var test = _appDbContext.Tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .Where(t => t.SubjectId == subjectId)
                .FirstOrDefault(t => t.Id == id);

            if (test == null)
            {
                throw new NotFoundException("Test not found");
            }

            var result = _mapper.Map<TestResponse>(test);
            return result;
        }

        public IEnumerable<TestResponse> GetTests(int subjectId)
        {
            _appDbContext.Tests
                .Where(t => t.SubjectId == subjectId)
                .ToList();

            var result = _mapper.Map<IEnumerable<TestResponse>>(_appDbContext.Tests);

            return result;
        }

        public void UpdateTest(int subjectId, int id, TestRequest testRequest)
        {
            var test = _appDbContext.Tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .Where(t => t.SubjectId == subjectId)
                .FirstOrDefault(t => id == t.Id);

            if(test == null)
            {
                throw new NotFoundException("Test not found");
            }

            test.Name = testRequest.Name != null ? testRequest.Name : test.Name;
            test.Description = testRequest.Description != null ? testRequest.Description : test.Description;

            foreach (var question in testRequest.Questions)
            {
                var questionToUpdate = test.Questions.FirstOrDefault(q => q.Id == question.Id);

                if(questionToUpdate == null)
                {
                    var newQuestion = _mapper.Map<Question>(question);
                    newQuestion.TestId = test.Id;
                    test.Questions.Add(newQuestion);
                }
                else
                {
                    questionToUpdate.Content = question.Content;

                    foreach (var answer in question.Answers)
                    {
                        var answerToUpdate = questionToUpdate.Answers.FirstOrDefault(a => a.Id == answer.Id);

                        if(answerToUpdate == null)
                        {
                            var newAnswer = _mapper.Map<Answer>(answer);
                            newAnswer.QuestionId = questionToUpdate.Id;
                            questionToUpdate.Answers.Add(newAnswer);
                        }
                        else
                        {
                            answerToUpdate.Content = answer.Content;
                            answerToUpdate.IsCorrect = answer.IsCorrect;
                        }
                    }
                }
            }

            _appDbContext.SaveChanges();
        }
    }
}
