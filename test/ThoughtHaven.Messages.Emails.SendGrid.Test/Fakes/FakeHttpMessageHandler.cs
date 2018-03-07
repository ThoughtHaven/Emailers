using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ThoughtHaven.Messages.Emails.SendGrid.Fakes
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public bool SendAsync_Called => this.SendAsync_InputRequest != null;
        public HttpRequestMessage SendAsync_InputRequest;
        public HttpResponseMessage SendAsync_Output = new HttpResponseMessage(HttpStatusCode.Accepted);
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            this.SendAsync_InputRequest = request;

            return Task.FromResult(this.SendAsync_Output);
        }
    }
}