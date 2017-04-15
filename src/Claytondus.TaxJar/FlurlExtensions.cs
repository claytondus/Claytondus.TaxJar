using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Flurl.Http.Content;

namespace Claytondus.TaxJar
{
    public static class FlurlExtensions
    {
        // chain off an existing FlurlClient:
        public static async Task<HttpResponseMessage> PostXmlAsync(this FlurlClient fc, string xml)
        {
            var content = new CapturedStringContent(xml, Encoding.UTF8, "application/xml");
            return await fc.HttpClient.PostAsync(fc.Url, content);
        }

        // chain off a Url object:
        public static Task<HttpResponseMessage> PostXmlAsync(this Url url, string xml)
        {
            return new FlurlClient(url, true).PostXmlAsync(xml);
        }

        // chain off a url string:
        public static Task<HttpResponseMessage> PostXmlAsync(this string url, string xml)
        {
            return new FlurlClient(url, true).PostXmlAsync(xml);
        }

        // chain off an existing FlurlClient:
        public static async Task<HttpResponseMessage> PostMultipartAsync(this FlurlClient fc, MultipartFormDataContent content)
        {
            var client = fc.HttpClient;
            return await client.PostAsync(fc.Url, content);
        }

        // chain off a Url object:
        public static Task<HttpResponseMessage> PostMultipartAsync(this Url url, MultipartFormDataContent content)
        {
            return new FlurlClient(url, true).PostMultipartAsync(content);
        }

        // chain off a url string:
        public static Task<HttpResponseMessage> PostMultipartAsync(this string url, MultipartFormDataContent content)
        {
            return new FlurlClient(url, true).PostMultipartAsync(content);
        }

        /// <summary>
        /// Sends an asynchronous PUT request.
        /// </summary>
        /// <param name="client">The Flurl client.</param>
        /// <param name="data">Contents of the request body.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation. Optional.</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <returns>A Task whose result is the received HttpResponseMessage.</returns>
        public static Task<HttpResponseMessage> PutUrlEncodedAsync(this FlurlClient client, object data, CancellationToken cancellationToken = default(CancellationToken), HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            var content = new CapturedUrlEncodedContent(client.Settings.UrlEncodedSerializer.Serialize(data));
            return client.SendAsync(HttpMethod.Put, content: content, cancellationToken: cancellationToken, completionOption: completionOption);
        }

        /// <summary>
        /// Creates a FlurlClient from the URL and sends an asynchronous PUT request.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="data">Contents of the request body.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation. Optional.</param>
        /// <param name="completionOption">The HttpCompletionOption used in the request. Optional.</param>
        /// <returns>A Task whose result is the received HttpResponseMessage.</returns>
        public static Task<HttpResponseMessage> PutUrlEncodedAsync(this Url url, object data, CancellationToken cancellationToken = default(CancellationToken), HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            return new FlurlClient(url, false).PutUrlEncodedAsync(data, cancellationToken, completionOption);
        }
    }
}