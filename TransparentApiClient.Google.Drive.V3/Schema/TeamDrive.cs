using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class TeamDrive { 

		/// <summary>
		/// An image file and cropping parameters from which a background image for this Team Drive is set. This is a write only field; it can only be set on drive.teamdrives.update requests that don't set themeId. When specified, all fields of the backgroundImageFile must be set.
		/// </summary>
		public object backgroundImageFile { get; set; }

		/// <summary>
		/// A short-lived link to this Team Drive's background image.
		/// </summary>
		public string backgroundImageLink { get; set; }

		/// <summary>
		/// Capabilities the current user has on this Team Drive.
		/// </summary>
		public object capabilities { get; set; }

		/// <summary>
		/// The color of this Team Drive as an RGB hex string. It can only be set on a drive.teamdrives.update request that does not set themeId.
		/// </summary>
		public string colorRgb { get; set; }

		/// <summary>
		/// The time at which the Team Drive was created (RFC 3339 date-time).
		/// </summary>
		public string createdTime { get; set; }

		/// <summary>
		/// The ID of this Team Drive which is also the ID of the top level folder for this Team Drive.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#teamDrive".
		/// </summary>
		public string kind { get; set; } = "drive#teamDrive";

		/// <summary>
		/// The name of this Team Drive.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The ID of the theme from which the background image and color will be set. The set of possible teamDriveThemes can be retrieved from a drive.about.get response. When not specified on a drive.teamdrives.create request, a random theme is chosen from which the background image and color are set. This is a write-only field; it can only be set on requests that don't set colorRgb or backgroundImageFile.
		/// </summary>
		public string themeId { get; set; }

	}
}