using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.BigQuery.V2.Schema;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources {

    /// <summary>
    /// Projects are top-level containers in the Google Cloud Platform. For more information, see Projects.
    /// The BigQuery API enables you to list projects by using the bigquery.projects.list method, but creating and managing projects occur outside of the API.For information about how to create or manage projects, see Managing Projects.
    /// For a list of methods for this resource, see the end of this page https://cloud.google.com/bigquery/docs/reference/rest/v2/projects.
    /// </summary>
    public interface IProjects {

        /// <summary>
        /// Returns the email address of the service account for your project used for interactions with Google Cloud KMS.
        /// </summary>
        /// <param name="projectId">Project ID for which the service account is requested.</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<GetServiceAccountResponse>> GetServiceAccountAsync(string projectId, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Lists all projects to which you have been granted any project role.
        /// </summary>
        /// <param name="maxResults">Maximum number of results to return</param>
        /// <param name="pageToken">Page token, returned by a previous call, to request the next page of results</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<ProjectList>> ListAsync(int? maxResults, string pageToken, JsonSerializerSettings settings, CancellationToken cancellationToken);

    }

}