using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class CallFunctionRequest { 

		/// <summary>
		/// Required. Input to be passed to the function.
		/// </summary>
		public string data { get; set; }

	}
}