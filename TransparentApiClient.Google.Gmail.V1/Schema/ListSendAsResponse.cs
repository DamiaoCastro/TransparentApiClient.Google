using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ListSendAsResponse { 

		/// <summary>
		/// List of send-as aliases.
		/// </summary>
		public IEnumerable<SendAs> sendAs { get; set; }

	}
}