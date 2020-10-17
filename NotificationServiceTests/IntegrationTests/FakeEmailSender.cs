using EmailService;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationServiceTests.IntegrationTests
{
    public class FakeEmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public FakeEmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.Add(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }
    }
}
