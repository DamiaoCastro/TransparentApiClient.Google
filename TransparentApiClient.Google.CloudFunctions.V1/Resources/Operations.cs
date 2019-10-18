using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.CloudFunctions.V1.Resources { 

	public class Operations : BaseClient {

		public Operations(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://cloudfunctions.googleapis.com/",
		    		new string[] {"https://www.googleapis.com/auth/cloud-platform"}) {
		}

		/// <summary>
		/// Lists operations that match the specified filter in the request. If the
		///server doesn't support this method, it returns `UNIMPLEMENTED`.
		///
		///NOTE: the `name` binding allows API services to override the binding
		///to use different resource name schemes, such as `users/*/operations`. To
		///override the binding, API services can add a binding such as
		///`"/v1/{name=users/*}/operations"` to their service configuration.
		///For backwards compatibility, the default name includes the operations
		///collection id, however overriding users must ensure the name binding
		///is the parent resource, without the operations collection id.
		/// </summary>
		/// <param name="filter">Required. A filter for matching the requested operations.<br><br> The supported formats of <b>filter</b> are:<br> To query for a specific function: <code>project:*,location:*,function:*</code><br> To query for all of the latest operations for a project: <code>project:*,latest:true</code></param>
		/// <param name="name">Must not be set.</param>
		/// <param name="pageToken">Token identifying which result to start with, which is returned by a previous list call.<br><br> Pagination is only supported when querying for a specific function.</param>
		/// <param name="pageSize">The maximum number of records that should be returned.<br> Requested page size cannot exceed 100. If not set, the default page size is 100.<br><br> Pagination is only supported when querying for a specific function.</param>
		public Task<BaseResponse<Schema.ListOperationsResponse>> ListAsync(string filter, string name, string pageToken, int? pageSize, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {

			string queryString = GetQueryString(new {filter, name, pageToken, pageSize});

			return SendAsync(HttpMethod.Get, $"v1/operations?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ListOperationsResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets the latest state of a long-running operation.  Clients can use this
		///method to poll the operation result at intervals as recommended by the API
		///service.
		/// </summary>
		/// <param name="name">The name of the operation resource.</param>
		public Task<BaseResponse<Schema.Operation>> GetAsync(string name, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }

			return SendAsync(HttpMethod.Get, $"v1/{name}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Operation>, cancellationToken)
				.Unwrap();
		}

	}

}