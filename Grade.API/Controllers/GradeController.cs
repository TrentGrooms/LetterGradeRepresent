using Grade.Common.Interfaces;
using Grade.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Grade.API.Controllers;




[ApiController]
[Route("api/grades")]
public class GradeController : ControllerBase
{
    private readonly IGradeCalculator _gradeCalculator;
    
    public GradeController(IGradeCalculator gradeCalculator)
    {
        _gradeCalculator = gradeCalculator;
    }

    [HttpPost("calculate")]
    public ActionResult<GradeResponse> GetGrade([FromBody] GradeRequest gradeRequest)
    {
        if (gradeRequest == null)
        {
            return BadRequest();
        }
        
        var percentage = gradeRequest.Percentage;
        var letterGrade = _gradeCalculator.CalculateGrade(percentage);

        var response = new GradeResponse()
        {
            OriginalPercentage = percentage,
            LetterGrade = letterGrade
        };
        
        return Ok(response);
    }
    
    
}