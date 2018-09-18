using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.BigQuery.V2.Schema;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources {

    /// <summary>
    /// Datasets allow you to organize and control access to your tables. For more information, see Datasets https://cloud.google.com/bigquery/docs/datasets.
    /// For a list of methods for this resource, see the end of this page. https://cloud.google.com/bigquery/docs/reference/rest/v2/datasets
    /// </summary>
    public interface IDatasets {

        /// <summary>
        /// Deletes the dataset specified by the datasetId value. Before you can delete a dataset, you must delete all its tables, either manually or by specifying deleteContents. Immediately after deletion, you can create another dataset with the same name.
        /// </summary>
        /// <param name="datasetId">Dataset ID of dataset being deleted</param>
        /// <param name="projectId">Project ID of the dataset being deleted</param>
        /// <param name="deleteContents">If True, delete all the tables in the dataset. If False and the dataset contains tables, the request will fail. Default is False</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<object>> DeleteAsync(string datasetId, string projectId, bool? deleteContents, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Returns the dataset specified by datasetID.
        /// </summary>
        /// <param name="datasetId">Dataset ID of the requested dataset</param>
        /// <param name="projectId">Project ID of the requested dataset</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<Dataset>> GetAsync(string datasetId, string projectId, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new empty dataset.
        /// </summary>
        /// <param name="projectId">Project ID of the new dataset</param>
        /// <param name="dataset"></param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<Dataset>> InsertAsync(string projectId, Dataset dataset, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Lists all datasets in the specified project to which you have been granted the READER dataset role.
        /// </summary>
        /// <param name="projectId">Project ID of the datasets to be listed</param>
        /// <param name="all">Whether to list all datasets, including hidden ones</param>
        /// <param name="filter">An expression for filtering the results of the request by label. The syntax is "labels.name[:value]". Multiple filters can be ANDed together by connecting with a space. Example: "labels.department:receiving labels.active". See Filtering datasets using labels for details.</param>
        /// <param name="maxResults">The maximum number of results to return</param>
        /// <param name="pageToken">Page token, returned by a previous call, to request the next page of results</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<DatasetList>> ListAsync(string projectId, bool? all, string filter, int? maxResults, string pageToken, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Updates information in an existing dataset. The update method replaces the entire dataset resource, whereas the patch method only replaces fields that are provided in the submitted dataset resource. This method supports patch semantics.
        /// </summary>
        /// <param name="datasetId">Dataset ID of the dataset being updated</param>
        /// <param name="projectId">Project ID of the dataset being updated</param>
        /// <param name="dataset"></param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<Dataset>> PatchAsync(string datasetId, string projectId, Dataset dataset, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Updates information in an existing dataset. The update method replaces the entire dataset resource, whereas the patch method only replaces fields that are provided in the submitted dataset resource.
        /// </summary>
        /// <param name="datasetId">Dataset ID of the dataset being updated</param>
        /// <param name="projectId">Project ID of the dataset being updated</param>
        /// <param name="dataset"></param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<Dataset>> UpdateAsync(string datasetId, string projectId, Dataset dataset, JsonSerializerSettings settings, CancellationToken cancellationToken);

    }
}