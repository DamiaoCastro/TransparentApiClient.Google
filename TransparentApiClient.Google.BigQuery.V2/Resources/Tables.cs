using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources { 

	public class Tables : BaseClient {

		public Tables(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/bigquery/v2/",
		    		new string[] {"https://www.googleapis.com/auth/bigquery","https://www.googleapis.com/auth/cloud-platform","https://www.googleapis.com/auth/cloud-platform.read-only"}) {
		}

		/// <summary>
		/// Deletes the table specified by tableId from the dataset. If the table contains data, all the data will be deleted.
		/// </summary>
		/// <param name="datasetId">Dataset ID of the table to delete</param>
		/// <param name="projectId">Project ID of the table to delete</param>
		/// <param name="tableId">Table ID of the table to delete</param>
		public Task<BaseResponse<object>> DeleteAsync(string datasetId, string projectId, string tableId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			return SendAsync(HttpMethod.Delete, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets the specified table resource by table ID. This method does not return the data in the table, it only returns the table resource, which describes the structure of this table.
		/// </summary>
		/// <param name="datasetId">Dataset ID of the requested table</param>
		/// <param name="projectId">Project ID of the requested table</param>
		/// <param name="tableId">Table ID of the requested table</param>
		/// <param name="selectedFields">List of fields to return (comma-separated). If unspecified, all fields are returned</param>
		public Task<BaseResponse<Schema.Table>> GetAsync(string datasetId, string projectId, string tableId, string selectedFields, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			string queryString = GetQueryString(new {selectedFields});

			return SendAsync(HttpMethod.Get, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Table>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Creates a new, empty table in the dataset.
		/// </summary>
		/// <param name="datasetId">Dataset ID of the new table</param>
		/// <param name="projectId">Project ID of the new table</param>
		public Task<BaseResponse<Schema.Table>> InsertAsync(string datasetId, string projectId, Schema.Table Table, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}/tables", Table, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Table>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists all tables in the specified dataset. Requires the READER dataset role.
		/// </summary>
		/// <param name="datasetId">Dataset ID of the tables to list</param>
		/// <param name="projectId">Project ID of the tables to list</param>
		/// <param name="maxResults">Maximum number of results to return</param>
		/// <param name="pageToken">Page token, returned by a previous call, to request the next page of results</param>
		public Task<BaseResponse<Schema.TableList>> ListAsync(string datasetId, string projectId, int? maxResults, string pageToken, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

			string queryString = GetQueryString(new {maxResults, pageToken});

			return SendAsync(HttpMethod.Get, $"projects/{projectId}/datasets/{datasetId}/tables?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.TableList>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates information in an existing table. The update method replaces the entire table resource, whereas the patch method only replaces fields that are provided in the submitted table resource. This method supports patch semantics.
		/// </summary>
		/// <param name="datasetId">Dataset ID of the table to update</param>
		/// <param name="projectId">Project ID of the table to update</param>
		/// <param name="tableId">Table ID of the table to update</param>
		public Task<BaseResponse<Schema.Table>> PatchAsync(string datasetId, string projectId, string tableId, Schema.Table Table, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			return SendAsync(new HttpMethod("PATCH"), $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}", Table, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Table>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates information in an existing table. The update method replaces the entire table resource, whereas the patch method only replaces fields that are provided in the submitted table resource.
		/// </summary>
		/// <param name="datasetId">Dataset ID of the table to update</param>
		/// <param name="projectId">Project ID of the table to update</param>
		/// <param name="tableId">Table ID of the table to update</param>
		public Task<BaseResponse<Schema.Table>> UpdateAsync(string datasetId, string projectId, string tableId, Schema.Table Table, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			return SendAsync(HttpMethod.Put, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}", Table, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Table>, cancellationToken)
				.Unwrap();
		}

	}

}