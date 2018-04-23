using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class Reply { 

		/// <summary>
		/// The action the reply performed to the parent comment. Valid values are:  
		///- resolve 
		///- reopen
		/// </summary>
		public string action { get; set; }

		/// <summary>
		/// The user who created the reply.
		/// </summary>
		public User author { get; set; }

		/// <summary>
		/// The plain text content of the reply. This field is used for setting the content, while htmlContent should be displayed. This is required on creates if no action is specified.
		/// </summary>
		public string content { get; set; }

		/// <summary>
		/// The time at which the reply was created (RFC 3339 date-time).
		/// </summary>
		public string createdTime { get; set; }

		/// <summary>
		/// Whether the reply has been deleted. A deleted reply has no content.
		/// </summary>
		public bool deleted { get; set; }

		/// <summary>
		/// The content of the reply with HTML formatting.
		/// </summary>
		public string htmlContent { get; set; }

		/// <summary>
		/// The ID of the reply.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#reply".
		/// </summary>
		public string kind { get; set; } = "drive#reply";

		/// <summary>
		/// The last time the reply was modified (RFC 3339 date-time).
		/// </summary>
		public string modifiedTime { get; set; }

	}
}