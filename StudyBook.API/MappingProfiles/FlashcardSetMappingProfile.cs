using AutoMapper;
using StudyBook.API.Entities;
using StudyBook.API.Models;

namespace StudyBook.API.MappingProfiles
{
    public class FlashcardSetMappingProfile : Profile
    {
        public FlashcardSetMappingProfile()
        {
            CreateMap<FlashcardSetRequest, FlashcardSet>();
            CreateMap<FlashcardRequest, Flashcard>();
            CreateMap<FlashcardSet, FlashcardSetResponse>();
            CreateMap<Flashcard, FlashcardResponse>();
        }
    }
}
