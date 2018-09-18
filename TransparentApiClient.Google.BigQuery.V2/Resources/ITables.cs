using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.BigQuery.V2.Schema;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources {

    /// <summary>
    /// A table is a part of a dataset https://cloud.google.com/bigquery/docs/reference/rest/v2/datasets. For more information, see Tables https://cloud.google.com/bigquery/docs/tables.
    /// For a list of methods for this resource, see the end of this page https://cloud.google.com/bigquery/docs/reference/rest/v2/tables.
    /// </summary>
    public interface ITables {

        /// <summary>
        /// Deletes the table specified by tableId from the dataset. If the table contains data, all the data will be deleted.
        /// </summary>
        /// <param name="datasetId">Dataset ID of the table to delete</param>
        /// <param name="projectId">Project ID of the table to delete</param>
        /// <param name="tableId">Table ID of the table to delete</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<object>> DeleteAsync(string datasetId, string projectId, string tableId, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified table resource by table ID. This method does not return the data in the table, it only returns the table resource, which describes the structure of this table.
        /// </summary>
        /// <param name="datasetId">Dataset ID of the requested table</param>
        /// <param name="projectId">Project ID of the requested table</param>
        /// <param name="tableId">Table ID of the requested table</param>
        /// <param name="selectedFields">List of fields to return (comma-separated). If unspecified, all fields are returned</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<Table>> GetAsync(string datasetId, string projectId, string tableId, string selectedFields, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new, empty table in the dataset.
        /// </summary>
        /// <param name="datasetId">Dataset ID of the new table</param>
        /// <param name="projectId">Project ID of the new table</param>
        /// <param name="table"></param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<Table>> InsertAsync(string datasetId, string projectId, Table table, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Lists all tables in the specified dataset. Requires the READER dataset role.
        /// </summary>
        /// <param name="datasetId">Dataset ID of the tables to list</param>
        /// <param name="projectId">Project ID of the tables to list</param>
        /// <param name="maxResults">Maximum number of results to return</param>
        /// <param name="pageToken">Page token, returned by a previous call, to request the next page of results</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<TableList>> ListAsync(string datasetId, string projectId, int? maxResults, string pageToken, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Updates information in an existing table. The update method replaces the entire table resource, whereas the patch method only replaces fields that are provided in the submitted table resource. This method supports patch semantics.
        /// </summary>
        /// <param name="datasetId">Dataset ID of the table to update</param>
        /// <param name="projectId">Project ID of the table to update</param>
        /// <param name="tableId">Table ID of the table to update</param>
        /// <param name="table"></param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<Table>> PatchAsync(string datasetId, string projectId, string tableId, Table table, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Updates information in an existing table. The update method replaces the entire table resource, whereas the patch method only replaces fields that are provided in the submitted table resource.
        /// </summary>
        /// <param name="datasetId">Dataset ID of the table to update</param>
        /// <param name="projectId">Project ID of the table to update</param>
        /// <param name="tableId">Table ID of the table to update</param>
        /// <param name="table"></param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<Table>> UpdateAsync(string datasetId, string projectId, string tableId, Table table, JsonSerializerSettings settings, CancellationToken cancellationToken);

    }

}