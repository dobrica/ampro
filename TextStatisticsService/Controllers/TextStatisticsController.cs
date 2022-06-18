using Microsoft.AspNetCore.Mvc;
using TextStatisticsService.BLL;

namespace TextStatisticsService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TextStatisticsController : ControllerBase
{
    public TextStatisticsController()
    {
    }

    [HttpPost("message/stats")]
    public IActionResult AnalyzeText([FromBody] MessageDTO messageDTO)
    {
        if(messageDTO.Body.Equals(String.Empty))
            return BadRequest("Message body is empty!");

        var messageStats = messageDTO.GetStats();

        if (messageStats is not null)
        {
            return Ok(messageDTO.GetStats());
        }
        return NotFound();
    }
}
