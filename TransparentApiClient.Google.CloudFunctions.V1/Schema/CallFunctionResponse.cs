using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class CallFunctionResponse { 

		/// <summary>
		/// Execution id of function invocation.
		/// </summary>
		public string executionId { get; set; }

		/// <summary>
		/// Result populated for successful execution of synchronous function. Will
		///not be populated if function does not return a result through context.
		/// </summary>
		public string result { get; set; }

		/// <summary>
		/// Either system or user-function generated error. Set if execution
		///was not successful.
		/// </summary>
		public string error { get; set; }

	}
}