using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class GenerateDownloadUrlResponse { 

		/// <summary>
		/// The generated Google Cloud Storage signed URL that should be used for
		///function source code download.
		/// </summary>
		public string downloadUrl { get; set; }

	}
}