using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ListSmimeInfoResponse { 

		/// <summary>
		/// List of SmimeInfo.
		/// </summary>
		public IEnumerable<SmimeInfo> smimeInfo { get; set; }

	}
}