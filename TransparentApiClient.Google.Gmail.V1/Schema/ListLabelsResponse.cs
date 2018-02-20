using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ListLabelsResponse { 

		/// <summary>
		/// List of labels.
		/// </summary>
		public IEnumerable<Label> labels { get; set; }

	}
}