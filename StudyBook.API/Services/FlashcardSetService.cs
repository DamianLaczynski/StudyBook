using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyBook.API.Entities;
using StudyBook.API.Models;
using StudyBookAPI.Exceptions;

namespace StudyBook.API.Services
{
    public interface IFlashcardSetService
    {
        IEnumerable<FlashcardSetResponse> GetFlashcardSets(int subjectId);
        FlashcardSetResponse GetFlashcardSet(int subjectId, int id);
        int CreateFlashcardSet(int subjectId, FlashcardSetRequest flashcardSetRequest);
        void UpdateFlashcardSet(int subjectId, int id, FlashcardSetRequest flashcardSetRequest);
        void DeleteFlashcardSet(int subjectId, int id);
    }

    public class FlashcardSetService : IFlashcardSetService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<FlashcardSetService> _logger;
        private readonly IMapper _mapper;

        public FlashcardSetService(AppDbContext appDbContext, ILogger<FlashcardSetService> logger, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public int CreateFlashcardSet(int subjectId, FlashcardSetRequest flashcardSetRequest)
        {
            var flashcardSet = _mapper.Map<FlashcardSet>(flashcardSetRequest);
            flashcardSet.SubjectId = subjectId;
            _appDbContext.Add(flashcardSet);

            _appDbContext.SaveChanges();

            return flashcardSet.Id;
        }

        public void DeleteFlashcardSet(int subjectId, int id)
        {
            _logger.LogInformation($"DELETE action invoked on flashcard set with id {id} for subject {subjectId}");

            var flashcardSet = _appDbContext.FlashcardSets
                .Where(fs => fs.SubjectId == subjectId)
                .FirstOrDefault(f => f.Id == id);

            if (flashcardSet == null)
            {
                throw new NotFoundException("Flashcard set not found");
            }

            _appDbContext.Remove(flashcardSet);
            _appDbContext.SaveChanges();
        }

        public FlashcardSetResponse GetFlashcardSet(int subjectId, int id)
        {
            var flashcardSet = _appDbContext.FlashcardSets
                .Include(f => f.Flashcards)
                .Where(fs => fs.SubjectId == subjectId)
                .FirstOrDefault(f => f.Id == id);

            if (flashcardSet == null)
            {
                throw new NotFoundException("Flashcard set not found");
            }

            var result = _mapper.Map<FlashcardSetResponse>(flashcardSet);

            return result;
        }

        public IEnumerable<FlashcardSetResponse> GetFlashcardSets(int subjectId)
        {
            var flashcardSets = _appDbContext.FlashcardSets
                .Where(fs => fs.SubjectId == subjectId)
                .ToList();

            var result = _mapper.Map<IEnumerable<FlashcardSetResponse>>(flashcardSets);

            return result;
        }

        public void UpdateFlashcardSet(int subjectId, int id, FlashcardSetRequest flashcardSetRequest)
        {
            var flashcardSet = _appDbContext.FlashcardSets
                .Include(fs => fs.Flashcards)
                .Where(fs => fs.SubjectId == subjectId)
                .FirstOrDefault(f => f.Id == id);

            if (flashcardSet == null)
            {
                throw new NotFoundException("Flashcard set not found");
            }

            flashcardSet.Name = flashcardSetRequest.Name != null ? flashcardSetRequest.Name : flashcardSet.Name;
            flashcardSet.Description = flashcardSetRequest.Description != null ? flashcardSetRequest.Description : flashcardSet.Description;

            foreach (var flashcardRequest in flashcardSetRequest.Flashcards)
            {
                var flashcard = flashcardSet.Flashcards.FirstOrDefault(f => f.Id == flashcardRequest.Id);
                if (flashcard != null)
                {
                    flashcard.Question = flashcardRequest.Question;
                    flashcard.Answer = flashcardRequest.Answer;
                }
                else
                {
                    var newFlashcard = _mapper.Map<Flashcard>(flashcardRequest);
                    newFlashcard.FlashcardSetId = flashcardSet.Id;
                    _appDbContext.Add(newFlashcard);
                }
            }

            _appDbContext.SaveChanges();

        }
    }
}