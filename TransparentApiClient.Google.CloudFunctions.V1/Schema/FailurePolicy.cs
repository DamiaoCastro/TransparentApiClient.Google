using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class FailurePolicy { 

		/// <summary>
		/// If specified, then the function will be retried in case of a failure.
		/// </summary>
		public Retry retry { get; set; }

	}
}