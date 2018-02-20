using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class TestIamPermissionsResponse { 

		/// <summary>
		/// A subset of `TestPermissionsRequest.permissions` that the caller is
allowed.
		/// </summary>
		public IEnumerable<object> permissions { get; set; }

	}
}