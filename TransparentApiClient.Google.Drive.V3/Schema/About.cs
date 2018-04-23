using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class About { 

		/// <summary>
		/// Whether the user has installed the requesting app.
		/// </summary>
		public bool appInstalled { get; set; }

		/// <summary>
		/// Whether the user can create Team Drives.
		/// </summary>
		public bool canCreateTeamDrives { get; set; }

		/// <summary>
		/// A map of source MIME type to possible targets for all supported exports.
		/// </summary>
		public object exportFormats { get; set; }

		/// <summary>
		/// The currently supported folder colors as RGB hex strings.
		/// </summary>
		public IEnumerable<object> folderColorPalette { get; set; }

		/// <summary>
		/// A map of source MIME type to possible targets for all supported imports.
		/// </summary>
		public object importFormats { get; set; }

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#about".
		/// </summary>
		public string kind { get; set; } = "drive#about";

		/// <summary>
		/// A map of maximum import sizes by MIME type, in bytes.
		/// </summary>
		public object maxImportSizes { get; set; }

		/// <summary>
		/// The maximum upload size in bytes.
		/// </summary>
		public string maxUploadSize { get; set; }

		/// <summary>
		/// The user's storage quota limits and usage. All fields are measured in bytes.
		/// </summary>
		public object storageQuota { get; set; }

		/// <summary>
		/// A list of themes that are supported for Team Drives.
		/// </summary>
		public IEnumerable<TeamDriveTheme> teamDriveThemes { get; set; }

		/// <summary>
		/// The authenticated user.
		/// </summary>
		public User user { get; set; }

	public class TeamDriveTheme { 

		/// <summary>
		/// A link to this Team Drive theme's background image.
		/// </summary>
		public string backgroundImageLink { get; set; }

		/// <summary>
		/// The color of this Team Drive theme as an RGB hex string.
		/// </summary>
		public string colorRgb { get; set; }

		/// <summary>
		/// The ID of the theme.
		/// </summary>
		public string id { get; set; }

	}
	}
}