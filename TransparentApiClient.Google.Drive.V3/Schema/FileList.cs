using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class FileList { 

		/// <summary>
		/// The list of files. If nextPageToken is populated, then this list may be incomplete and an additional page of results should be fetched.
		/// </summary>
		public IEnumerable<File> files { get; set; }

		/// <summary>
		/// Whether the search process was incomplete. If true, then some search results may be missing, since all documents were not searched. This may occur when searching multiple Team Drives with the "user,allTeamDrives" corpora, but all corpora could not be searched. When this happens, it is suggested that clients narrow their query by choosing a different corpus such as "user" or "teamDrive".
		/// </summary>
		public bool incompleteSearch { get; set; }

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#fileList".
		/// </summary>
		public string kind { get; set; } = "drive#fileList";

		/// <summary>
		/// The page token for the next page of files. This will be absent if the end of the files list has been reached. If the token is rejected for any reason, it should be discarded, and pagination should be restarted from the first page of results.
		/// </summary>
		public string nextPageToken { get; set; }

	}
}