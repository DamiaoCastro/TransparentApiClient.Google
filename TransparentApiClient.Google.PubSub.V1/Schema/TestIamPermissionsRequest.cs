using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class TestIamPermissionsRequest { 

		/// <summary>
		/// The set of permissions to check for the `resource`. Permissions with
		///wildcards (such as '*' or 'storage.*') are not allowed. For more
		///information see
		///[IAM Overview](https://cloud.google.com/iam/docs/overview#permissions).
		/// </summary>
		public IEnumerable<object> permissions { get; set; }

	}
}