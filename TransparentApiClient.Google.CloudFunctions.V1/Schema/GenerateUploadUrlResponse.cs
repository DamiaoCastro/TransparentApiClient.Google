using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class GenerateUploadUrlResponse { 

		/// <summary>
		/// The generated Google Cloud Storage signed URL that should be used for a
		///function source code upload. The uploaded file should be a zip archive
		///which contains a function.
		/// </summary>
		public string uploadUrl { get; set; }

	}
}