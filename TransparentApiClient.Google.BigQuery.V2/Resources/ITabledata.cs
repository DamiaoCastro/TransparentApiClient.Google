using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.BigQuery.V2.Schema;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources {

    /// <summary>
    /// Tabledata is used to return a slice of rows from a specified table. All columns are returned. Each row is actually a Tabledata resource; to get a slice of rows, you call bigquery.tabledata.list(). Specify a zero-based start row and a number of rows to retrieve in the list() request. Results are paged if the number of rows exceeds the maximum for a single page of data. The column order will be the order specified by the table schema.
    /// For a list of methods for this resource, see the end of this page https://cloud.google.com/bigquery/docs/reference/rest/v2/tabledata.
    /// </summary>
    public interface ITabledata {

        /// <summary>
        /// Streams data into BigQuery one record at a time without needing to run a load job. Requires the WRITER dataset role.
        /// </summary>
        /// <param name="datasetId">Dataset ID of the destination table.</param>
        /// <param name="projectId">Project ID of the destination table.</param>
        /// <param name="tableId">Table ID of the destination table.</param>
        /// <param name="tableDataInsertAllRequest"></param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<TableDataInsertAllResponse>> InsertAllAsync(string datasetId, string projectId, string tableId, TableDataInsertAllRequest tableDataInsertAllRequest, JsonSerializerSettings settings, CancellationToken cancellationToken);

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
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<TableDataList>> ListAsync(string datasetId, string projectId, string tableId, int? maxResults, string pageToken, string selectedFields, string startIndex, JsonSerializerSettings settings, CancellationToken cancellationToken);

    }

}