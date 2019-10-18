using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class ListFunctionsResponse { 

		/// <summary>
		/// If not empty, indicates that there may be more functions that match
		///the request; this value should be passed in a new
		///google.cloud.functions.v1.ListFunctionsRequest
		///to get more functions.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// The functions that match the request.
		/// </summary>
		public IEnumerable<CloudFunction> functions { get; set; }

	}
}