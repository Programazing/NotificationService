using EmailService.DTO;
using EmailService.Helpers;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailService
{
    public class Message
    {
        public MailboxAddress To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(string to, string subject, string content)
        {
            if (!to.IsValidEmail())
            {
                throw new ArgumentException("Email address is invalid.");
            }

            To = new MailboxAddress(to);
            Subject = subject;
            Content = content;
        }
        public static implicit operator Message(MessageDTO input)
        {
            return new Message(input.To, input.Subject, input.Content);
        }
    }
}
