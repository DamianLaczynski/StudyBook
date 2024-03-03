using Microsoft.AspNetCore.Mvc;
using StudyBook.API.Models;
using StudyBook.API.Services;

namespace StudyBook.API.Controllers
{
    [ApiController]
    [Route("api/subject/{subjectId}/test")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        /// <summary>
        /// Get all tests
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTests([FromRoute]int subjectId)
        {
            var tests = _testService.GetTests(subjectId);
            return Ok(tests);
        }
        
        /// <summary>
        /// Get test by id
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult GetTest([FromRoute]int subjectId, [FromRoute] int id)
        {
            var test = _testService.GetTest(subjectId, id);
            return Ok(test);
        }

        /// <summary>
        /// Create test
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="testRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateTest([FromRoute] int subjectId, [FromBody] TestRequest testRequest)
        {
            var id = _testService.CreateTest(subjectId, testRequest);
            return Created($"/api/subject/{subjectId}/test/{id}", null);
        }

        /// <summary>
        /// Update test
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="id"></param>
        /// <param name="testRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateTest([FromRoute] int subjectId, [FromRoute]int id, [FromBody] TestRequest testRequest)
        {
            _testService.UpdateTest(subjectId, id, testRequest);
            return Ok();
        }

        /// <summary>
        /// Delete test
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteTest([FromRoute] int subjectId, [FromRoute]int id)
        {
            _testService.DeleteTest(subjectId, id);
            return NoContent();
        }

    }
}
