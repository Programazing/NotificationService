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
            var request = new Request();

            var response = await TestClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task SendEmail_Returns400_WhenGivenMisformedEmailAddress()
        {
            var request = new Request();
            request.Body.To = "email@email";

            var response = await TestClient.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            response.StatusCode.Should().Be(400);
        }
    }
}
