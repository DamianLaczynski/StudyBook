using AutoMapper;
using StudyBook.API.Entities;
using StudyBook.API.Models;

namespace StudyBook.API.MappingProfiles
{
    public class SubjectMappingProfile : Profile
    {
        public SubjectMappingProfile()
        {
            CreateMap<SubjectRequest, Subject>();
            CreateMap<Subject, SubjectResponse>();
            CreateMap<UpdateSubjectRequest, Subject>();
        }
    }
}
