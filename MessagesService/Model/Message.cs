using System;

namespace MessagesService.Model {
    public class Message {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string From {get; set;} = String.Empty;
        public string Body {get; set;} = String.Empty;
    }
}