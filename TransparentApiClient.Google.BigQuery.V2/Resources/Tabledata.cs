using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources {

    /// <summary>
    /// Tabledata is used to return a slice of rows from a specified table. All columns are returned. Each row is actually a Tabledata resource; to get a slice of rows, you call bigquery.tabledata.list(). Specify a zero-based start row and a number of rows to retrieve in the list() request. Results are paged if the number of rows exceeds the maximum for a single page of data. The column order will be the order specified by the table schema.
    /// For a list of methods for this resource, see the end of this page https://cloud.google.com/bigquery/docs/reference/rest/v2/tabledata.
    /// </summary>
    public class Tabledata : BaseClient, ITabledata
    {

        /// <summary>
        /// constructor with mandatory serviceAccountCredentials
        /// </summary>
        /// <param name="serviceAccountCredentials"></param>
        public Tabledata(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/bigquery/v2/",
		    		new string[] {"https://www.googleapis.com/auth/bigquery","https://www.googleapis.com/auth/bigquery.insertdata","https://www.googleapis.com/auth/cloud-platform","https://www.googleapis.com/auth/cloud-platform.read-only"}) {
		}
        		
		Task<BaseResponse<Schema.TableDataInsertAllResponse>> ITabledata.InsertAllAsync(string datasetId, string projectId, string tableId, Schema.TableDataInsertAllRequest TableDataInsertAllRequest, JsonSerializerSettings settings, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}/insertAll", TableDataInsertAllRequest, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.TableDataInsertAllResponse>, cancellationToken)
				.Unwrap();
		}

		Task<BaseResponse<Schema.TableDataList>> ITabledata.ListAsync(string datasetId, string projectId, string tableId, int? maxResults, string pageToken, string selectedFields, string startIndex, JsonSerializerSettings settings, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
			if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

			string queryString = GetQueryString(new {maxResults, pageToken, selectedFields, startIndex});

			return SendAsync(HttpMethod.Get, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}/data?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.TableDataList>, cancellationToken)
				.Unwrap();
		}

	}

}