using EmailService;
using EmailService.DTO;
using FluentAssertions;
using MimeKit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificationServiceTests.IntegrationTests
{
    [TestFixture]
    public class EmailControllerIntegrationTests : IntegrationTest
    {
        [Test]
        public async Task SendEmail_Returns_200_WhenGivenValidMessage()
        {
            var request = new
            {
                Url = "/api/sendemail",
                Body = new MessageDTO()
                {
                    To = "email@email.com",
                    Subject = "Some Subject I made up",
                    Content = "Oh look, content."
                }
            };

            var response = await TestClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            response.StatusCode.Should().Be(200);
        }
    }
}
