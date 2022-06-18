using System;
using System.Collections.Generic;
using System.Linq;
using MessagesService.Model;
using Microsoft.EntityFrameworkCore;

namespace MessagesService.DAL;

public class MessageRepository : IMessageRepository, IDisposable
{
    private DataContext context;

    public MessageRepository(DataContext context)
    {
        this.context = context;
    }
    public IEnumerable<Message> GetMessages()
    {
        return context.Messages.ToList();
    }
    public Message? GetMessageByID(int messageId)
    {
        var message = context.Messages.Find(messageId);
        if (message is not null)
            return message;
        return null;
    }
    public void InsertMessage(Message message)
    {
        if (message is null)
            return;

        if (GetMessageByID(message.Id) is null)
        {
            context.Messages.Add(message);
            Save();
        }
    }
    public void UpdateMessage(Message message)
    {
        if (message is null)
            return;

        context.Messages.Update(message);
        Save();
    }
    public void DeleteMessage(int messageId)
    {
        var message = GetMessageByID(messageId);
        if (message is not null)
        {
            context.Messages.Remove(message);
            Save();
        }
    }
    public void Save()
    {
        context.SaveChanges();
    }
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}