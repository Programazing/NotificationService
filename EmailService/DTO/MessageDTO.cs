using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService.DTO
{
    public class MessageDTO
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public MessageDTO()
        {

        }
    }
}
