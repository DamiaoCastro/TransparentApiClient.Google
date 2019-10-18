using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class Status { 

		/// <summary>
		/// A list of messages that carry the error details.  There is a common set of
		///message types for APIs to use.
		/// </summary>
		public IEnumerable<object> details { get; set; }

		/// <summary>
		/// The status code, which should be an enum value of google.rpc.Code.
		/// </summary>
		public int code { get; set; }

		/// <summary>
		/// A developer-facing error message, which should be in English. Any
		///user-facing error message should be localized and sent in the
		///google.rpc.Status.details field, or localized by the client.
		/// </summary>
		public string message { get; set; }

	}
}