using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Claytondus.TaxJar.Logging;
using Claytondus.TaxJar.Models;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace Claytondus.TaxJar
{
    public class RestClient
    {
	    protected readonly string TaxJarUrl = "https://api.taxjar.com/v2";
	    private readonly string _authToken;
        private static readonly ILog Log = LogProvider.For<RestClient>();

        public RestClient()
		{
		}

		public RestClient(string authToken)
		{
			_authToken = authToken;
		}

	    protected async Task<T> GetAsync<T>(string resource, object queryParams = null) where T : class
	    {
            Log.Trace("GET " + resource);
		    try
		    {
			    var response = await new Url(TaxJarUrl)
				    .AppendPathSegment(resource)
				    .SetQueryParams(queryParams)
				    .WithDefaults()
				    .WithOAuthBearerToken(_authToken)
					.GetAsync();
                Log.Trace(response.RequestMessage.ToString);
			    var responseBody = await response.Content.ReadAsStringAsync();
				var settings = new JsonSerializerSettings
				{
					Error = (sender, args) =>
					{
						if (System.Diagnostics.Debugger.IsAttached)
						{
							System.Diagnostics.Debugger.Break();
						}
					}
				};
			    var responseDeserialized = JsonConvert.DeserializeObject<T>(responseBody, settings);
			    return responseDeserialized;
		    }
			catch (FlurlHttpTimeoutException)
			{
				throw new TaxJarException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
			    var response = await ex.Call.Response.Content.ReadAsStringAsync();
                var TaxJarEx = new TaxJarException("error", response) { Method = "GET", Resource = resource, HttpStatus = ex.Call.HttpStatus};
                throw TaxJarEx;
            }
		}

		protected async Task<T> PostAsync<T>(string resource, object body)
	    {
            Log.Trace("POST " + resource);
            try
			{
				var request =  new Url(TaxJarUrl)
                    .AppendPathSegment(resource)
					.WithDefaults()
			        .WithOAuthBearerToken(_authToken);
			    return await request.PostUrlEncodedAsync(body)
					.ReceiveJson<T>();
			}
			catch (FlurlHttpTimeoutException)
			{
				throw new TaxJarException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = await ex.Call.Response.Content.ReadAsStringAsync();
                var TaxJarEx = new TaxJarException("error", response) { Method = "POST", Resource = resource, HttpStatus = ex.Call.HttpStatus, HttpMessage = ex.Message, RequestBody = ex.Call.RequestBody};
                throw TaxJarEx;
            }
			
	    }

		protected async Task<T> PutAsync<T>(string resource, object body = null)
		{
            Log.Trace("PUT " + resource);
            try
			{
				var request = new Url(TaxJarUrl)
                    .AppendPathSegment(resource)
					.WithDefaults()
					.WithOAuthBearerToken(_authToken);
				var response = await request.SendUrlEncodedAsync(HttpMethod.Put, body)
					.ReceiveJson<T>();
			    return response;
			}
			catch (FlurlHttpTimeoutException)
			{
				throw new TaxJarException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = await ex.Call.Response.Content.ReadAsStringAsync();
                var TaxJarEx = new TaxJarException("error", response) { Method = "PUT", Resource = resource, HttpStatus = ex.Call.HttpStatus, HttpMessage = ex.Message, RequestBody = ex.Call.RequestBody };
                throw TaxJarEx;
            }
		}

        protected async Task DeleteAsync(string resource, object queryParams = null)
        {
            Log.Trace("DELETE " + resource);
            try
            {
                await new Url(TaxJarUrl)
                    .AppendPathSegment(resource)
                    .SetQueryParams(queryParams)
                    .WithDefaults()
                    .WithOAuthBearerToken(_authToken)
                    .DeleteAsync();
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new TaxJarException("timeout", "Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                var response = await ex.Call.Response.Content.ReadAsStringAsync();
                var TaxJarEx = new TaxJarException("error", response) { Method = "DELETE", Resource = resource, HttpStatus = ex.Call.HttpStatus, HttpMessage = ex.Message };
                throw TaxJarEx;
            }
        }

        protected async Task<T> DeleteAsync<T>(string resource, object queryParams = null)
		{
            Log.Trace("DELETE " + resource);
            try
            {
                var response = await new Url(TaxJarUrl)
                    .AppendPathSegment(resource)
                    .SetQueryParams(queryParams)
                    .WithDefaults()
                    .WithOAuthBearerToken(_authToken)
                    .DeleteAsync()
                    .ReceiveJson<T>();
                return response;
            }
			catch (FlurlHttpTimeoutException)
			{
				throw new TaxJarException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = await ex.Call.Response.Content.ReadAsStringAsync();
                var TaxJarEx = new TaxJarException("error", response) { Method = "DELETE", Resource = resource, HttpStatus = ex.Call.HttpStatus, HttpMessage = ex.Message };
                throw TaxJarEx;
            }
        }
	}

	public static class UrlExtension
	{
		public static IFlurlRequest WithDefaults(this Url url)
		{
			return url
				.WithTimeout(10)
				.WithHeader("Accept", "application/json");
		}
	}
}
