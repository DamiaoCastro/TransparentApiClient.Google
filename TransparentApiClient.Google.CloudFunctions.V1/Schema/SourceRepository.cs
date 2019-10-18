using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class SourceRepository { 

		/// <summary>
		/// The URL pointing to the hosted repository where the function is defined.
		///There are supported Cloud Source Repository URLs in the following
		///formats:
		///
		///To refer to a specific commit:
		///`https://source.developers.google.com/projects/*/repos/*/revisions/*/paths/*`
		///To refer to a moveable alias (branch):
		///`https://source.developers.google.com/projects/*/repos/*/moveable-aliases/*/paths/*`
		///In particular, to refer to HEAD use `master` moveable alias.
		///To refer to a specific fixed alias (tag):
		///`https://source.developers.google.com/projects/*/repos/*/fixed-aliases/*/paths/*`
		///
		///You may omit `paths/*` if you want to use the main directory.
		/// </summary>
		public string url { get; set; }

		/// <summary>
		/// Output only. The URL pointing to the hosted repository where the function
		///were defined at the time of deployment. It always points to a specific
		///commit in the format described above.
		/// </summary>
		public string deployedUrl { get; set; }

	}
}