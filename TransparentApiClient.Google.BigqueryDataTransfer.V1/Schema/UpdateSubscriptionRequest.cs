using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigqueryDataTransfer.V1.Schema { 
	public class UpdateSubscriptionRequest { 

		/// <summary>
		/// The updated subscription object.
		/// </summary>
		public Subscription subscription { get; set; }

		/// <summary>
		/// Indicates which fields in the provided subscription to update.
		///Must be specified and non-empty.
		/// </summary>
		public string updateMask { get; set; }

	}
}