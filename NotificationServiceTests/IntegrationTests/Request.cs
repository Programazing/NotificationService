using EmailService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationServiceTests.IntegrationTests
{
    public class Request
    {
        public string Url { get; set; }
        public MessageDTO Body { get; set; }

        public Request(string url, MessageDTO body)
        {
            Url = url;
            Body = body;
        }

        public Request()
        {
            Url = "/api/sendemail";
            Body = new MessageDTO()
            {
                To = "email@email.com",
                Subject = "Some Subject I made up",
                Content = "Oh look, content."
            };
        }
    }
}
