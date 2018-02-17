using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class UserDefinedFunctionResource { 

		/// <summary>
		/// [Pick one] An inline resource that contains code for a user-defined function (UDF). Providing a inline code resource is equivalent to providing a URI for a file containing the same code.
		/// </summary>
		public string inlineCode { get; set; }

		/// <summary>
		/// [Pick one] A code resource to load from a Google Cloud Storage URI (gs://bucket/path).
		/// </summary>
		public string resourceUri { get; set; }

	}
}