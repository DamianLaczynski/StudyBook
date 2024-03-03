using AutoMapper;
using StudyBook.API.Entities;
using StudyBook.API.Models;

namespace StudyBook.API.MappingProfiles
{
    public class TestMappingProfile : Profile
    {
        public TestMappingProfile()
        {
            CreateMap<Test, TestResponse>();
            CreateMap<TestRequest, Test>();

            //QuestionMappingProfile
            CreateMap<QuestionRequest, Question>();
            CreateMap<Question, QuestionResponse>();

            //AnswerMappingProfile
            CreateMap<AnswerRequest, Answer>();
            CreateMap<Answer, AnswerResponse>();
        }
    }
}
