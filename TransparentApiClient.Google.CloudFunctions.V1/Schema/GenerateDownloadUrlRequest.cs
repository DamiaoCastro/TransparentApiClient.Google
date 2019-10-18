using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class GenerateDownloadUrlRequest { 

		/// <summary>
		/// The optional version of function. If not set, default, current version
		///is used.
		/// </summary>
		public string versionId { get; set; }

	}
}