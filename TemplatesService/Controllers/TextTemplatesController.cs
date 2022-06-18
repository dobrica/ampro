using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TemplateService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TextTemplatesController : ControllerBase
{
    private IMongoClient client;
    private IMongoCollection<TextTemplate> collection;

    public TextTemplatesController(IMongoClient client)
    {
        this.client = client;
        var database = client.GetDatabase("TextTemplates");
        collection = database.GetCollection<TextTemplate>("Templates");
    }

    [HttpGet("getall")]
    public IActionResult GetAllMessages()
    {
        var textTemplates = collection.Find(x => true).ToList();
        if (textTemplates is not null)
            return Ok(textTemplates);
        return NotFound();
    }

    [HttpGet("get/{id}")]
    public IActionResult GetMessageById(int id)
    {
        var textTemplate = collection.Find(x=>true).ToList().SingleOrDefault(x=>x.PrimaryId==id);
        if (textTemplate is not null)
            return Ok(textTemplate);
        return NotFound();
    }
}