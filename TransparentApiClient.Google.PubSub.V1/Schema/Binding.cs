using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class Binding { 

		/// <summary>
		/// Specifies the identities requesting access for a Cloud Platform resource.
		///`members` can have the following values:
		///
		///* `allUsers`: A special identifier that represents anyone who is
		///   on the internet; with or without a Google account.
		///
		///* `allAuthenticatedUsers`: A special identifier that represents anyone
		///   who is authenticated with a Google account or a service account.
		///
		///* `user:{emailid}`: An email address that represents a specific Google
		///   account. For example, `alice@gmail.com` or `joe@example.com`.
		///
		///
		///* `serviceAccount:{emailid}`: An email address that represents a service
		///   account. For example, `my-other-app@appspot.gserviceaccount.com`.
		///
		///* `group:{emailid}`: An email address that represents a Google group.
		///   For example, `admins@example.com`.
		///
		///
		///* `domain:{domain}`: A Google Apps domain name that represents all the
		///   users of that domain. For example, `google.com` or `example.com`.
		///
		///
		/// </summary>
		public IEnumerable<object> members { get; set; }

		/// <summary>
		/// Role that is assigned to `members`.
		///For example, `roles/viewer`, `roles/editor`, or `roles/owner`.
		///Required
		/// </summary>
		public string role { get; set; }

	}
}