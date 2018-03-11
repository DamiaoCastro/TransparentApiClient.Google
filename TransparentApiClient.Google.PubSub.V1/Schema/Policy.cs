using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class Policy { 

		/// <summary>
		/// `etag` is used for optimistic concurrency control as a way to help
		///prevent simultaneous updates of a policy from overwriting each other.
		///It is strongly suggested that systems make use of the `etag` in the
		///read-modify-write cycle to perform policy updates in order to avoid race
		///conditions: An `etag` is returned in the response to `getIamPolicy`, and
		///systems are expected to put that etag in the request to `setIamPolicy` to
		///ensure that their change will be applied to the same version of the policy.
		///
		///If no `etag` is provided in the call to `setIamPolicy`, then the existing
		///policy is overwritten blindly.
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// Deprecated.
		/// </summary>
		public int version { get; set; }

		/// <summary>
		/// Associates a list of `members` to a `role`.
		///`bindings` with no members will result in an error.
		/// </summary>
		public IEnumerable<Binding> bindings { get; set; }

	}
}