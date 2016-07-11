using System;
using System.Net;
using Newtonsoft.Json;

namespace Claytondus.TaxJar.Models
{
	public class TaxJarException : Exception
	{
		[JsonConstructor]
		public TaxJarException(string type, string message) : base(message)
		{
			TaxJarType = type;
		    ResponseBody = message;
		}

		public string TaxJarType { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }

		public HttpStatusCode? HttpStatus { get; set; }

        public string Method { get; set; }
        public string Resource { get; set; }
        public string HttpMessage { get; set; }


	}
}
