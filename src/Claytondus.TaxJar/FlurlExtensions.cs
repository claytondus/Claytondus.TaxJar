using System.Net.Http;
using System.Text;
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
    }
}