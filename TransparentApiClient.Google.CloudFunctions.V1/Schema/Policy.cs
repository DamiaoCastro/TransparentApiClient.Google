using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class Policy { 

		/// <summary>
		/// Associates a list of `members` to a `role`. Optionally may specify a
		///`condition` that determines when binding is in effect.
		///`bindings` with no members will result in an error.
		/// </summary>
		public IEnumerable<Binding> bindings { get; set; }

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
		///policy is overwritten. Due to blind-set semantics of an etag-less policy,
		///'setIamPolicy' will not fail even if either of incoming or stored policy
		///does not meet the version requirements.
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// Specifies the format of the policy.
		///
		///Valid values are 0, 1, and 3. Requests specifying an invalid value will be
		///rejected.
		///
		///Operations affecting conditional bindings must specify version 3. This can
		///be either setting a conditional policy, modifying a conditional binding,
		///or removing a conditional binding from the stored conditional policy.
		///Operations on non-conditional policies may specify any valid value or
		///leave the field unset.
		///
		///If no etag is provided in the call to `setIamPolicy`, any version
		///compliance checks on the incoming and/or stored policy is skipped.
		/// </summary>
		public int version { get; set; }

		/// <summary>
		/// Specifies cloud audit logging configuration for this policy.
		/// </summary>
		public IEnumerable<AuditConfig> auditConfigs { get; set; }

	}
}