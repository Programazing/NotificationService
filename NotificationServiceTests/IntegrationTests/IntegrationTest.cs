using EmailService;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NotificationService;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace NotificationServiceTests.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor =
                        new ServiceDescriptor(
                            typeof(IEmailSender),
                            typeof(FakeEmailSender),
                            ServiceLifetime.Transient);
                        services.Replace(descriptor);
                    });
                });

            TestClient = appFactory.CreateClient();
        }

    }
}
