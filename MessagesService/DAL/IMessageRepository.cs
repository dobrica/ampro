using System;
using System.Collections.Generic;
using MessagesService.Model;

namespace MessagesService.DAL;

public interface IMessageRepository : IDisposable
{
    IEnumerable<Message> GetMessages();
    Message? GetMessageByID(int messageId);
    void InsertMessage(Message message);
    void DeleteMessage(int messageId);
    void UpdateMessage(Message message);
    void Save();
}