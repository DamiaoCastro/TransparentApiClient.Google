using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.BigQuery.V2.Schema;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources {

    /// <summary>
    /// Jobs are objects that manage asynchronous tasks such as running queries, loading data, and exporting data. You can run multiple jobs concurrently in BigQuery, and completed jobs will be listed in the Jobs collection.
    /// The Jobs collection stores your project's complete job history, but availability is only guaranteed for jobs created in the past six months. To request automatic deletion of jobs that are more than 50 days old, contact support.
    /// Each job resource includes one of the following child properties, which defines the job type
    /// </summary>
    public interface IJobs {

        /// <summary>
        /// Requests that a job be cancelled. This call will return immediately, and the client will need to poll for the job status to see if the cancel completed successfully. Cancelled jobs may still incur costs.
        /// </summary>
        /// <param name="jobId">[Required] Job ID of the job to cancel</param>
        /// <param name="projectId">[Required] Project ID of the job to cancel</param>
        /// <param name="location">[Experimental] The geographic location of the job. Required except for US and EU.</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<JobCancelResponse>> CancelAsync(string jobId, string projectId, string location, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Returns information about a specific job. Job information is available for a six month period after creation. Requires that you're the person who ran the job, or have the Is Owner project role.
        /// </summary>
        /// <param name="jobId">[Required] Job ID of the requested job</param>
        /// <param name="projectId">[Required] Project ID of the requested job</param>
        /// <param name="location">[Experimental] The geographic location of the job. Required except for US and EU.</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<Job>> GetAsync(string jobId, string projectId, string location, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves the results of a query job.
        /// </summary>
        /// <param name="jobId">[Required] Job ID of the query job</param>
        /// <param name="projectId">[Required] Project ID of the query job</param>
        /// <param name="location">[Experimental] The geographic location where the job should run. Required except for US and EU.</param>
        /// <param name="maxResults">Maximum number of results to read</param>
        /// <param name="pageToken">Page token, returned by a previous call, to request the next page of results</param>
        /// <param name="startIndex">Zero-based index of the starting row</param>
        /// <param name="timeoutMs">How long to wait for the query to complete, in milliseconds, before returning. Default is 10 seconds. If the timeout passes before the job completes, the 'jobComplete' field in the response will be false</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<GetQueryResultsResponse>> GetQueryResultsAsync(string jobId, string projectId, string location, int? maxResults, string pageToken, string startIndex, int? timeoutMs, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Starts a new asynchronous job. Requires the Can View project role.
        /// </summary>
        /// <param name="projectId">Project ID of the project that will be billed for the job</param>
        /// <param name="job"></param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<Job>> InsertAsync(string projectId, Job job, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Lists all jobs that you started in the specified project. Job information is available for a six month period after creation. The job list is sorted in reverse chronological order, by job creation time. Requires the Can View project role, or the Is Owner project role if you set the allUsers property.
        /// </summary>
        /// <param name="projectId">Project ID of the jobs to list</param>
        /// <param name="allUsers">Whether to display jobs owned by all users in the project. Default false</param>
        /// <param name="maxCreationTime">Max value for job creation time, in milliseconds since the POSIX epoch. If set, only jobs created before or at this timestamp are returned</param>
        /// <param name="maxResults">Maximum number of results to return</param>
        /// <param name="minCreationTime">Min value for job creation time, in milliseconds since the POSIX epoch. If set, only jobs created after or at this timestamp are returned</param>
        /// <param name="pageToken">Page token, returned by a previous call, to request the next page of results</param>
        /// <param name="projection">Restrict information returned to a set of selected fields</param>
        /// <param name="stateFilter">Filter for job state</param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<JobList>> ListAsync(string projectId, bool? allUsers, string maxCreationTime, int? maxResults, string minCreationTime, string pageToken, string projection, string stateFilter, JsonSerializerSettings settings, CancellationToken cancellationToken);

        /// <summary>
        /// Runs a BigQuery SQL query synchronously and returns query results if the query completes within a specified timeout.
        /// </summary>
        /// <param name="projectId">Project ID of the project billed for the query</param>
        /// <param name="queryRequest"></param>
        /// <param name="settings">optional JsonConvert serialization settings. Null by default</param>
        /// <param name="cancellationToken">Task cancellation token.</param>
        Task<BaseResponse<QueryResponse>> QueryAsync(string projectId, QueryRequest queryRequest, JsonSerializerSettings settings, CancellationToken cancellationToken);

    }

}