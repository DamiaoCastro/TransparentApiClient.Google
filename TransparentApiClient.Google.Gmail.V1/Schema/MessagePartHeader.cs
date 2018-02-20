using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class MessagePartHeader { 

		/// <summary>
		/// The name of the header before the : separator. For example, To.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The value of the header after the : separator. For example, someuser@example.com.
		/// </summary>
		public string value { get; set; }

	}
}