using System.Collections.Generic;
using MessagesService.DAL;
using MessagesService.Model;
using Microsoft.AspNetCore.Mvc;

namespace MessagesService.Controllers;

[ApiController]
[Route("api")]
public class MessagesController : ControllerBase
{
    private IMessageRepository messageRepository;

    public MessagesController(IMessageRepository messageRepository)
    {
        this.messageRepository = messageRepository;
    }

    [HttpGet("getall")]
    public IActionResult GetAllMessages()
    {
        var messages = messageRepository.GetMessages();
        if (messages is not null)
            return Ok(messages);
        return NotFound();
    }

    [HttpGet("get/{id}")]
    public IActionResult GetMessage(int id)
    {
        var message = messageRepository.GetMessageByID(id);
        if (message is not null)
            return Ok(message);
        return NotFound();
    }

    [HttpPost("add")]
    public IActionResult AddMessage([FromBody] Message message)
    {
        message.Date = DateTime.UtcNow;
        if (message.Body is not null)
        {
            messageRepository.InsertMessage(message);
            var addedMsg = messageRepository.GetMessageByID(message.Id);
            return Ok(addedMsg);
        }
        return BadRequest();
    }

    [HttpPost("update")]
    public IActionResult UpdateMessage([FromBody] Message message)
    {
        if (message.Body is not null)
        {
            messageRepository.UpdateMessage(message);
            var updatedMsg = messageRepository.GetMessageByID(message.Id);
            return Ok(updatedMsg);
        }
        return BadRequest();
    }

    [HttpPost("delete/{id}")]
    public IActionResult DeleteMessage(int id)
    {
        if (id != 0 && id > 0)
        {
            messageRepository.DeleteMessage(id);
            return Ok();
        }
        return BadRequest();
    }
}