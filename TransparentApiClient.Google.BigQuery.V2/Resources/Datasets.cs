using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources { 

	public class Datasets : BaseClient {

		public Datasets(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/bigquery/v2/",
		    		new string[] {"https://www.googleapis.com/auth/bigquery","https://www.googleapis.com/auth/cloud-platform","https://www.googleapis.com/auth/cloud-platform.read-only"}) {
		}

		/// <summary>
		/// Deletes the dataset specified by the datasetId value. Before you can delete a dataset, you must delete all its tables, either manually or by specifying deleteContents. Immediately after deletion, you can create another dataset with the same name.
		/// </summary>
		/// <param name="datasetId">Dataset ID of dataset being deleted</param>
		/// <param name="projectId">Project ID of the dataset being deleted</param>
		/// <param name="deleteContents">If True, delete all the tables in the dataset. If False and the dataset contains tables, the request will fail. Default is False</param>
		public Task<BaseResponse<object>> DeleteAsync(string datasetId, string projectId, bool? deleteContents, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

			string queryString = GetQueryString(new {deleteContents});

			return SendAsync(HttpMethod.Delete, $"projects/{projectId}/datasets/{datasetId}?{queryString}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Returns the dataset specified by datasetID.
		/// </summary>
		/// <param name="datasetId">Dataset ID of the requested dataset</param>
		/// <param name="projectId">Project ID of the requested dataset</param>
		public Task<BaseResponse<Schema.Dataset>> GetAsync(string datasetId, string projectId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

			return SendAsync(HttpMethod.Get, $"projects/{projectId}/datasets/{datasetId}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Dataset>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Creates a new empty dataset.
		/// </summary>
		/// <param name="projectId">Project ID of the new dataset</param>
		public Task<BaseResponse<Schema.Dataset>> InsertAsync(string projectId, Schema.Dataset Dataset, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets", Dataset, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Dataset>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists all datasets in the specified project to which you have been granted the READER dataset role.
		/// </summary>
		/// <param name="projectId">Project ID of the datasets to be listed</param>
		/// <param name="all">Whether to list all datasets, including hidden ones</param>
		/// <param name="filter">An expression for filtering the results of the request by label. The syntax is "labels.<name>[:<value>]". Multiple filters can be ANDed together by connecting with a space. Example: "labels.department:receiving labels.active". See Filtering datasets using labels for details.</param>
		/// <param name="maxResults">The maximum number of results to return</param>
		/// <param name="pageToken">Page token, returned by a previous call, to request the next page of results</param>
		public Task<BaseResponse<Schema.DatasetList>> ListAsync(string projectId, bool? all, string filter, int? maxResults, string pageToken, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

			string queryString = GetQueryString(new {all, filter, maxResults, pageToken});

			return SendAsync(HttpMethod.Get, $"projects/{projectId}/datasets?{queryString}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.DatasetList>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates information in an existing dataset. The update method replaces the entire dataset resource, whereas the patch method only replaces fields that are provided in the submitted dataset resource. This method supports patch semantics.
		/// </summary>
		/// <param name="datasetId">Dataset ID of the dataset being updated</param>
		/// <param name="projectId">Project ID of the dataset being updated</param>
		public Task<BaseResponse<Schema.Dataset>> PatchAsync(string datasetId, string projectId, Schema.Dataset Dataset, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}", Dataset, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Dataset>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates information in an existing dataset. The update method replaces the entire dataset resource, whereas the patch method only replaces fields that are provided in the submitted dataset resource.
		/// </summary>
		/// <param name="datasetId">Dataset ID of the dataset being updated</param>
		/// <param name="projectId">Project ID of the dataset being updated</param>
		public Task<BaseResponse<Schema.Dataset>> UpdateAsync(string datasetId, string projectId, Schema.Dataset Dataset, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

			return SendAsync(HttpMethod.Put, $"projects/{projectId}/datasets/{datasetId}", Dataset, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Dataset>, cancellationToken)
				.Unwrap();
		}

	}

}