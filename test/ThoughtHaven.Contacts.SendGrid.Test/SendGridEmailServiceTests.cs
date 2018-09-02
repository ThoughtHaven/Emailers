using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ThoughtHaven.Contacts.SendGrid.Fakes;
using Xunit;

namespace ThoughtHaven.Contacts.SendGrid
{
    public class SendGridEmailServiceTests
    {
        public class Constructor
        {
            public class ConfigurationOverload
            {
                [Fact]
                public void NullOptions_Throws()
                {
                    Assert.Throws<ArgumentNullException>("configuration", () =>
                    {
                        new SendGridEmailService(configuration: null);
                    });
                }
            }
        }

        public class SendMethod
        {
            public class MessageOverload
            {
                [Fact]
                public async Task NullMessage_Throws()
                {
                    await Assert.ThrowsAsync<ArgumentNullException>("message", async () =>
                    {
                        await Service().Send(message: null);
                    });
                }

                [Fact]
                public async Task WhenCalled_CallsSendOnHandler()
                {
                    var handler = Handler();

                    await Service(handler).Send(Message());

                    Assert.True(handler.SendAsync_Called);
                }

                [Fact]
                public async Task WhenCalled_SendsWithCorrectFrom()
                {
                    var handler = Handler();

                    await Service(handler).Send(Message());

                    var content = await handler.SendAsync_InputRequest.Content
                        .ReadAsStringAsync();

                    Assert.Contains("\"from\":{\"email\":\"from@email.com\"}", content);
                }

                [Fact]
                public async Task WhenCalled_SendsWithCorrectSubject()
                {
                    var handler = Handler();

                    await Service(handler).Send(Message());

                    var content = await handler.SendAsync_InputRequest.Content
                        .ReadAsStringAsync();

                    Assert.Contains("\"subject\":\"subject\"", content);
                }

                [Fact]
                public async Task ToOnePerson_SendsWithCorrectTo()
                {
                    var handler = Handler();

                    await Service(handler).Send(Message());

                    var content = await handler.SendAsync_InputRequest.Content
                        .ReadAsStringAsync();

                    Assert.Contains("\"to\":[{\"email\":\"to@email.com\"}]", content);
                }

                [Fact]
                public async Task ToTwoPeople_SendsWithCorrectTo()
                {
                    var handler = Handler();
                    var message = Message();
                    message = new EmailMessage(message.From, new EmailContact[]
                    {
                        new EmailContact("to1@email.com"),
                        new EmailContact("to2@email.com"),
                    }, message.Subject, message.Contents);

                    await Service(handler).Send(message);

                    var content = await handler.SendAsync_InputRequest.Content
                        .ReadAsStringAsync();

                    Assert.Contains("\"to\":[{\"email\":\"to1@email.com\"},{\"email\":\"to2@email.com\"}]", content);
                }

                [Fact]
                public async Task OneContent_SendsWithCorrectContent()
                {
                    var handler = Handler();

                    await Service(handler).Send(Message());

                    var content = await handler.SendAsync_InputRequest.Content
                        .ReadAsStringAsync();

                    Assert.Contains("\"content\":[{\"type\":\"text/plain\",\"value\":\"pt\"}]",
                        content);
                }

                [Fact]
                public async Task TwoContents_SendsWithCorrectContent()
                {
                    var handler = Handler();
                    var message = Message();
                    message = new EmailMessage(message.From, message.To, message.Subject,
                        new EmailContent[]
                        {
                            EmailContent.PlainText("pt"),
                            EmailContent.Html("html"),
                        });

                    await Service(handler).Send(message);

                    var content = await handler.SendAsync_InputRequest.Content
                        .ReadAsStringAsync();

                    Assert.Contains("\"content\":[{\"type\":\"text/plain\",\"value\":\"pt\"},{\"type\":\"text/html\",\"value\":\"html\"}]",
                        content);
                }

                [Fact]
                public async Task HandlerReturnsStatusCodeUnder200_Throws()
                {
                    var handler = Handler();
                    handler.SendAsync_Output = new HttpResponseMessage(HttpStatusCode.Continue)
                    {
                        Content = new StringContent("content")
                    };

                    var exception = await Assert.ThrowsAsync<Exception>(async () =>
                    {
                        await Service(handler).Send(Message());
                    });

                    Assert.Equal("Failed to send email message via SendGrid. Status Code: 100. Message: content",
                        exception.Message);
                }

                [Fact]
                public async Task HandlerReturnsStatusCodeAbove299_Throws()
                {
                    var handler = Handler();
                    handler.SendAsync_Output = new HttpResponseMessage(HttpStatusCode.Ambiguous)
                    {
                        Content = new StringContent("content")
                    };

                    var exception = await Assert.ThrowsAsync<Exception>(async () =>
                    {
                        await Service(handler).Send(Message());
                    });

                    Assert.Equal("Failed to send email message via SendGrid. Status Code: 300. Message: content",
                        exception.Message);
                }
            }
        }

        private static FakeHttpMessageHandler Handler() => new FakeHttpMessageHandler();
        private static FakeSendGridEmailService Service(
            FakeHttpMessageHandler handler = null) =>
            new FakeSendGridEmailService(handler ?? Handler());
        private static EmailMessage Message() =>
            new EmailMessage(new EmailContact("from@email.com"),
                new EmailContact("to@email.com"), "subject", EmailContent.PlainText("pt"));
    }
}