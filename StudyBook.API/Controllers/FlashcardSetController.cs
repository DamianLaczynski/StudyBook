using Microsoft.AspNetCore.Mvc;
using StudyBook.API.Models;
using StudyBook.API.Services;

namespace StudyBook.API.Controllers
{
    [ApiController]
    [Route("api/subject/{subjectId}/flashcardSet")]
    public class FlashcardSetController : ControllerBase
    {
        private readonly IFlashcardSetService _flashcardSetService;
        public FlashcardSetController(IFlashcardSetService flashcardSetService)
        {
            _flashcardSetService = flashcardSetService;
        }

        /// <summary>
        /// Get all flashcard sets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<FlashcardSetResponse>> GetFlashcardSets([FromRoute]int subjectId)
        {
            var flashcardSets = _flashcardSetService.GetFlashcardSets(subjectId);
            return Ok(flashcardSets);
        }

        /// <summary>
        /// Get flashcard set by id
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<FlashcardSetResponse> GetFlashcardSet([FromRoute] int subjectId, [FromRoute] int id)
        {
            var flashcardSet = _flashcardSetService.GetFlashcardSet(subjectId, id);
            return Ok(flashcardSet);
        }

        /// <summary>
        /// Create flashcard set
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="flashcardSetRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateFlashcardSet([FromRoute] int subjectId, [FromBody] FlashcardSetRequest flashcardSetRequest)
        {
            var id = _flashcardSetService.CreateFlashcardSet(subjectId, flashcardSetRequest);
            return Created($"/api/subject/{subjectId}/flashcardSet/{id}", null);
        }

        /// <summary>
        /// Update flashcard set
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="id"></param>
        /// <param name="flashcardSetRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateFlashcardSet([FromRoute] int subjectId, [FromRoute] int id, [FromBody] FlashcardSetRequest flashcardSetRequest)
        {
            _flashcardSetService.UpdateFlashcardSet(subjectId, id, flashcardSetRequest);
            return Ok();
        }

        /// <summary>
        /// Delete flashcard set
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteFlashcardSet([FromRoute] int subjectId, [FromRoute] int id)
        {
            _flashcardSetService.DeleteFlashcardSet(subjectId, id);
            return NoContent();
        }
    }
}
