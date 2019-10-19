using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.CloudFunctions.V1.Resources { 

	public class Locations : BaseClient {

		public Locations(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://cloudfunctions.googleapis.com/",
		    		new string[] {"https://www.googleapis.com/auth/cloud-platform"}) {
		}

		/// <summary>
		/// Lists information about the supported locations for this service.
		/// </summary>
		/// <param name="name">The resource that owns the locations collection, if applicable.</param>
		/// <param name="pageToken">The standard list page token.</param>
		/// <param name="pageSize">The standard list page size.</param>
		/// <param name="filter">The standard list filter.</param>
		public Task<BaseResponse<Schema.ListLocationsResponse>> ListAsync(string name, string pageToken, int? pageSize, string filter, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }

			string queryString = GetQueryString(new {pageToken, pageSize, filter});

			return SendAsync(HttpMethod.Get, $"v1/{name}/locations?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ListLocationsResponse>, cancellationToken)
				.Unwrap();
		}

	}

}