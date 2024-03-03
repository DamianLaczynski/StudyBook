using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudyBook.API.Models;
using StudyBook.API.Services;

namespace StudyBook.API.Controllers
{
    [ApiController]
    [Route("api/subject")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// Get all subjects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<SubjectResponse>> GetSubjects()
        {
            var result = _subjectService.GetSubjects();
            return Ok(result);
        }

        /// <summary>
        /// Get subject by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<SubjectResponse> GetSubject([FromRoute] int id)
        {
            var subject = _subjectService.GetSubjectById(id);
            return Ok(subject);
        }

        /// <summary>
        /// Create a new subject
        /// </summary>
        /// <param name="subjectRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateSubject([FromBody] SubjectRequest subjectRequest)
        {
            var id = _subjectService.CreateSubject(subjectRequest);
            return Created($"/api/subject/{id}", null);
        }

        /// <summary>
        /// Update a subject
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateSubjectRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateSubject([FromRoute] int id, [FromBody] UpdateSubjectRequest updateSubjectRequest)
        {
            _subjectService.UpdateSubject(id, updateSubjectRequest);
            return Ok();
        }

        /// <summary>
        /// Delete a subject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteSubject([FromRoute] int id)
        {
            _subjectService.DeleteSubject(id);
            return NoContent();
        }
    }
}
