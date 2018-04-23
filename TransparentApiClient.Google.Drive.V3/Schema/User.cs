using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class User { 

		/// <summary>
		/// A plain text displayable name for this user.
		/// </summary>
		public string displayName { get; set; }

		/// <summary>
		/// The email address of the user. This may not be present in certain contexts if the user has not made their email address visible to the requester.
		/// </summary>
		public string emailAddress { get; set; }

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#user".
		/// </summary>
		public string kind { get; set; } = "drive#user";

		/// <summary>
		/// Whether this user is the requesting user.
		/// </summary>
		public bool me { get; set; }

		/// <summary>
		/// The user's ID as visible in Permission resources.
		/// </summary>
		public string permissionId { get; set; }

		/// <summary>
		/// A link to the user's profile photo, if available.
		/// </summary>
		public string photoLink { get; set; }

	}
}