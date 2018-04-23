using System.Collections.Generic;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class Channel { 

		/// <summary>
		/// The address where notifications are delivered for this channel.
		/// </summary>
		public string address { get; set; }

		/// <summary>
		/// Date and time of notification channel expiration, expressed as a Unix timestamp, in milliseconds. Optional.
		/// </summary>
		public string expiration { get; set; }

		/// <summary>
		/// A UUID or similar unique string that identifies this channel.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Identifies this as a notification channel used to watch for changes to a resource. Value: the fixed string "api#channel".
		/// </summary>
		public string kind { get; set; } = "api#channel";

		/// <summary>
		/// Additional parameters controlling delivery channel behavior. Optional.
		/// </summary>
		public object @params { get; set; }

		/// <summary>
		/// A Boolean value to indicate whether payload is wanted. Optional.
		/// </summary>
		public bool payload { get; set; }

		/// <summary>
		/// An opaque ID that identifies the resource being watched on this channel. Stable across different API versions.
		/// </summary>
		public string resourceId { get; set; }

		/// <summary>
		/// A version-specific identifier for the watched resource.
		/// </summary>
		public string resourceUri { get; set; }

		/// <summary>
		/// An arbitrary string delivered to the target address with each notification delivered over this channel. Optional.
		/// </summary>
		public string token { get; set; }

		/// <summary>
		/// The type of delivery mechanism used for this channel.
		/// </summary>
		public string type { get; set; }

	}
}