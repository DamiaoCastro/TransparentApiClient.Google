using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class SetIamPolicyRequest { 

		/// <summary>
		/// OPTIONAL: A FieldMask specifying which fields of the policy to modify. Only
		///the fields in the mask will be modified. If no mask is provided, the
		///following default mask is used:
		///paths: "bindings, etag"
		///This field is only used by Cloud IAM.
		/// </summary>
		public string updateMask { get; set; }

		/// <summary>
		/// REQUIRED: The complete policy to be applied to the `resource`. The size of
		///the policy is limited to a few 10s of KB. An empty policy is a
		///valid policy but certain Cloud Platform services (such as Projects)
		///might reject them.
		/// </summary>
		public Policy policy { get; set; }

	}
}