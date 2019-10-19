using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.CloudFunctions.V1.Resources { 

	public class Functions : BaseClient {

		public Functions(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://cloudfunctions.googleapis.com/",
		    		new string[] {"https://www.googleapis.com/auth/cloud-platform"}) {
		}

		/// <summary>
		/// Returns a list of functions that belong to the requested project.
		/// </summary>
		/// <param name="parent">The project and location from which the function should be listed,
		///specified in the format `projects/*/locations/*`
		///If you want to list functions in all locations, use "-" in place of a
		///location.</param>
		/// <param name="pageToken">The value returned by the last
		///`ListFunctionsResponse`; indicates that
		///this is a continuation of a prior `ListFunctions` call, and that the
		///system should return the next page of data.</param>
		/// <param name="pageSize">Maximum number of functions to return per call.</param>
		public Task<BaseResponse<Schema.ListFunctionsResponse>> ListAsync(string parent, string pageToken, int? pageSize, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(parent)) { throw new ArgumentNullException(nameof(parent)); }

			string queryString = GetQueryString(new {pageToken, pageSize});

			return SendAsync(HttpMethod.Get, $"v1/{parent}/functions?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ListFunctionsResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Sets the IAM access control policy on the specified function.
		///Replaces any existing policy.
		/// </summary>
		/// <param name="resource">REQUIRED: The resource for which the policy is being specified.
		///See the operation documentation for the appropriate value for this field.</param>
		public Task<BaseResponse<Schema.Policy>> SetIamPolicyAsync(string resource, Schema.SetIamPolicyRequest SetIamPolicyRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(resource)) { throw new ArgumentNullException(nameof(resource)); }

			return SendAsync(HttpMethod.Post, $"v1/{resource}:setIamPolicy", SetIamPolicyRequest, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Policy>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Synchronously invokes a deployed Cloud Function. To be used for testing
		///purposes as very limited traffic is allowed. For more information on
		///the actual limits, refer to
		///[Rate Limits](https://cloud.google.com/functions/quotas#rate_limits).
		/// </summary>
		/// <param name="name">Required. The name of the function to be called.</param>
		public Task<BaseResponse<Schema.CallFunctionResponse>> CallAsync(string name, Schema.CallFunctionRequest CallFunctionRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }

			return SendAsync(HttpMethod.Post, $"v1/{name}:call", CallFunctionRequest, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.CallFunctionResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Creates a new function. If a function with the given name already exists in
		///the specified project, the long running operation will return
		///`ALREADY_EXISTS` error.
		/// </summary>
		/// <param name="location">Required. The project and location in which the function should be created, specified
		///in the format `projects/*/locations/*`</param>
		public Task<BaseResponse<Schema.Operation>> CreateAsync(string location, Schema.CloudFunction CloudFunction, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(location)) { throw new ArgumentNullException(nameof(location)); }

			return SendAsync(HttpMethod.Post, $"v1/{location}/functions", CloudFunction, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Operation>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Returns a signed URL for uploading a function source code.
		///For more information about the signed URL usage see:
		///https://cloud.google.com/storage/docs/access-control/signed-urls.
		///Once the function source code upload is complete, the used signed
		///URL should be provided in CreateFunction or UpdateFunction request
		///as a reference to the function source code.
		///
		///When uploading source code to the generated signed URL, please follow
		///these restrictions:
		///
		///* Source file type should be a zip file.
		///* Source file size should not exceed 100MB limit.
		///* No credentials should be attached - the signed URLs provide access to the
		///  target bucket using internal service identity; if credentials were
		///  attached, the identity from the credentials would be used, but that
		///  identity does not have permissions to upload files to the URL.
		///
		///When making a HTTP PUT request, these two headers need to be specified:
		///
		///* `content-type: application/zip`
		///* `x-goog-content-length-range: 0,104857600`
		///
		///And this header SHOULD NOT be specified:
		///
		///* `Authorization: Bearer YOUR_TOKEN`
		/// </summary>
		/// <param name="parent">The project and location in which the Google Cloud Storage signed URL
		///should be generated, specified in the format `projects/*/locations/*`.</param>
		public Task<BaseResponse<Schema.GenerateUploadUrlResponse>> GenerateUploadUrlAsync(string parent, Schema.GenerateUploadUrlRequest GenerateUploadUrlRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(parent)) { throw new ArgumentNullException(nameof(parent)); }

			return SendAsync(HttpMethod.Post, $"v1/{parent}/functions:generateUploadUrl", GenerateUploadUrlRequest, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.GenerateUploadUrlResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Returns a signed URL for downloading deployed function source code.
		///The URL is only valid for a limited period and should be used within
		///minutes after generation.
		///For more information about the signed URL usage see:
		///https://cloud.google.com/storage/docs/access-control/signed-urls
		/// </summary>
		/// <param name="name">The name of function for which source code Google Cloud Storage signed
		///URL should be generated.</param>
		public Task<BaseResponse<Schema.GenerateDownloadUrlResponse>> GenerateDownloadUrlAsync(string name, Schema.GenerateDownloadUrlRequest GenerateDownloadUrlRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }

			return SendAsync(HttpMethod.Post, $"v1/{name}:generateDownloadUrl", GenerateDownloadUrlRequest, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.GenerateDownloadUrlResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets the IAM access control policy for a function.
		///Returns an empty policy if the function exists and does not have a policy
		///set.
		/// </summary>
		/// <param name="resource">REQUIRED: The resource for which the policy is being requested.
		///See the operation documentation for the appropriate value for this field.</param>
		/// <param name="options.requestedPolicyVersion">Optional. The policy format version to be returned.
		///
		///Valid values are 0, 1, and 3. Requests specifying an invalid value will be
		///rejected.
		///
		///Requests for policies with any conditional bindings must specify version 3.
		///Policies without any conditional bindings may specify any valid value or
		///leave the field unset.</param>
		public Task<BaseResponse<Schema.Policy>> GetIamPolicyAsync(string resource, int? requestedPolicyVersion, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(resource)) { throw new ArgumentNullException(nameof(resource)); }

			string queryString = GetQueryString(new {requestedPolicyVersion});

			return SendAsync(HttpMethod.Get, $"v1/{resource}:getIamPolicy?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Policy>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates existing function.
		/// </summary>
		/// <param name="name">A user-defined name of the function. Function names must be unique
		///globally and match pattern `projects/*/locations/*/functions/*`</param>
		/// <param name="updateMask">Required list of fields to be updated in this request.</param>
		public Task<BaseResponse<Schema.Operation>> PatchAsync(string name, string updateMask, Schema.CloudFunction CloudFunction, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }

			string queryString = GetQueryString(new {updateMask});

			return SendAsync(HttpMethod.Post, $"v1/{name}?{queryString}", CloudFunction, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Operation>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Returns a function with the given name from the requested project.
		/// </summary>
		/// <param name="name">Required. The name of the function which details should be obtained.</param>
		public Task<BaseResponse<Schema.CloudFunction>> GetAsync(string name, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }

			return SendAsync(HttpMethod.Get, $"v1/{name}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.CloudFunction>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Tests the specified permissions against the IAM access control policy
		///for a function.
		///If the function does not exist, this will return an empty set of
		///permissions, not a NOT_FOUND error.
		/// </summary>
		/// <param name="resource">REQUIRED: The resource for which the policy detail is being requested.
		///See the operation documentation for the appropriate value for this field.</param>
		public Task<BaseResponse<Schema.TestIamPermissionsResponse>> TestIamPermissionsAsync(string resource, Schema.TestIamPermissionsRequest TestIamPermissionsRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(resource)) { throw new ArgumentNullException(nameof(resource)); }

			return SendAsync(HttpMethod.Post, $"v1/{resource}:testIamPermissions", TestIamPermissionsRequest, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.TestIamPermissionsResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Deletes a function with the given name from the specified project. If the
		///given function is used by some trigger, the trigger will be updated to
		///remove this function.
		/// </summary>
		/// <param name="name">Required. The name of the function which should be deleted.</param>
		public Task<BaseResponse<Schema.Operation>> DeleteAsync(string name, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }

			return SendAsync(HttpMethod.Delete, $"v1/{name}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Operation>, cancellationToken)
				.Unwrap();
		}

	}

}