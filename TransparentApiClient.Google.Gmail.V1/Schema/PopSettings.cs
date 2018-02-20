using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class PopSettings { 

		/// <summary>
		/// The range of messages which are accessible via POP.
		/// </summary>
		public string accessWindow { get; set; }

		/// <summary>
		/// The action that will be executed on a message after it has been fetched via POP.
		/// </summary>
		public string disposition { get; set; }

	}
}