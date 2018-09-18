using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources {

    /// <summary>
    /// A table is a part of a dataset https://cloud.google.com/bigquery/docs/reference/rest/v2/datasets. For more information, see Tables https://cloud.google.com/bigquery/docs/tables.
    /// For a list of methods for this resource, see the end of this page https://cloud.google.com/bigquery/docs/reference/rest/v2/tables.
    /// </summary>
    public class Tables : BaseClient, ITables
    {

        /// <summary>
        /// constructor with mandatory serviceAccountCredentials
        /// </summary>
        /// <param name="serviceAccountCredentials"></param>
        public Tables(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/bigquery/v2/",
		    		new string[] {"https://www.googleapis.com/auth/bigquery","https://www.googleapis.com/auth/cloud-platform","https://www.googleapis.com/auth/cloud-platform.read-only"}) {
		}

		Task<BaseResponse<object>> ITables.DeleteAsync(string datasetId, string projectId, string tableId, JsonSerializerSettings settings, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			return SendAsync(HttpMethod.Delete, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		Task<BaseResponse<Schema.Table>> ITables.GetAsync(string datasetId, string projectId, string tableId, string selectedFields, JsonSerializerSettings settings, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			string queryString = GetQueryString(new {selectedFields});

			return SendAsync(HttpMethod.Get, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Table>, cancellationToken)
				.Unwrap();
		}

		Task<BaseResponse<Schema.Table>> ITables.InsertAsync(string datasetId, string projectId, Schema.Table Table, JsonSerializerSettings settings, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}/tables", Table, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Table>, cancellationToken)
				.Unwrap();
		}

		Task<BaseResponse<Schema.TableList>> ITables.ListAsync(string datasetId, string projectId, int? maxResults, string pageToken, JsonSerializerSettings settings, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

			string queryString = GetQueryString(new {maxResults, pageToken});

			return SendAsync(HttpMethod.Get, $"projects/{projectId}/datasets/{datasetId}/tables?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.TableList>, cancellationToken)
				.Unwrap();
		}
        		
		Task<BaseResponse<Schema.Table>> ITables.PatchAsync(string datasetId, string projectId, string tableId, Schema.Table Table, JsonSerializerSettings settings, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			return SendAsync(new HttpMethod("PATCH"), $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}", Table, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Table>, cancellationToken)
				.Unwrap();
		}
        		
		Task<BaseResponse<Schema.Table>> ITables.UpdateAsync(string datasetId, string projectId, string tableId, Schema.Table Table, JsonSerializerSettings settings, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			return SendAsync(HttpMethod.Put, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}", Table, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Table>, cancellationToken)
				.Unwrap();
		}

	}

}