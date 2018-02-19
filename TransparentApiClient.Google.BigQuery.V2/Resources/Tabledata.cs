using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources { 

	public class Tabledata : BaseClient {

		public Tabledata(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/bigquery/v2/",
		    		new string[] {"https://www.googleapis.com/auth/bigquery","https://www.googleapis.com/auth/bigquery.insertdata","https://www.googleapis.com/auth/cloud-platform","https://www.googleapis.com/auth/cloud-platform.read-only"}) {
		}

		/// <summary>
		/// Streams data into BigQuery one record at a time without needing to run a load job. Requires the WRITER dataset role.
		/// </summary>
		/// <param name="datasetId">Dataset ID of the destination table.</param>
		/// <param name="projectId">Project ID of the destination table.</param>
		/// <param name="tableId">Table ID of the destination table.</param>
		public Task<BaseResponse<Schema.TableDataInsertAllResponse>> InsertAllAsync(string datasetId, string projectId, string tableId, Schema.TableDataInsertAllRequest TableDataInsertAllRequest, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}/insertAll", TableDataInsertAllRequest, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.TableDataInsertAllResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Retrieves table data from a specified set of rows. Requires the READER dataset role.
		/// </summary>
		/// <param name="datasetId">Dataset ID of the table to read</param>
		/// <param name="projectId">Project ID of the table to read</param>
		/// <param name="tableId">Table ID of the table to read</param>
		/// <param name="maxResults">Maximum number of results to return</param>
		/// <param name="pageToken">Page token, returned by a previous call, identifying the result set</param>
		/// <param name="selectedFields">List of fields to return (comma-separated). If unspecified, all fields are returned</param>
		/// <param name="startIndex">Zero-based index of the starting row to read</param>
		public Task<BaseResponse<Schema.TableDataList>> ListAsync(string datasetId, string projectId, string tableId, int? maxResults, string pageToken, string selectedFields, string startIndex, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			string queryString = GetQueryString(new {maxResults, pageToken, selectedFields, startIndex});

			return SendAsync(HttpMethod.Get, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}/data?{queryString}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.TableDataList>, cancellationToken)
				.Unwrap();
		}

	}

}