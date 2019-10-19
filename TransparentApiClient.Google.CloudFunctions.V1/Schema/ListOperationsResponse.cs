using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class ListOperationsResponse { 

		/// <summary>
		/// A list of operations that matches the specified filter in the request.
		/// </summary>
		public IEnumerable<Operation> operations { get; set; }

		/// <summary>
		/// The standard List next-page token.
		/// </summary>
		public string nextPageToken { get; set; }

	}
}