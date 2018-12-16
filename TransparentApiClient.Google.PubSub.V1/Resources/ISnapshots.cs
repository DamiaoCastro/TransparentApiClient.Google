using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;
using TransparentApiClient.Google.PubSub.V1.Schema;

namespace TransparentApiClient.Google.PubSub.V1.Resources {
    public interface ISnapshots {

        /// <summary>
        /// Creates a snapshot from the requested subscription.
        ///If the snapshot already exists, returns `ALREADY_EXISTS`.
        ///If the requested subscription doesn't exist, returns `NOT_FOUND`.
        ///If the backlog in the subscription is too old -- and the resulting snapshot
        ///would expire in less than 1 hour -- then `FAILED_PRECONDITION` is returned.
        ///See also the `Snapshot.expire_time` field.
        ///
        ///If the name is not provided in the request, the server will assign a random
        ///name for this snapshot on the same project as the subscription, conforming
        ///to the
        ///[resource name
        ///format](https://cloud.google.com/pubsub/docs/overview#names). The generated
        ///name is populated in the returned Snapshot object. Note that for REST API
        ///requests, you must specify a name in the request.
        /// </summary>
        /// <param name="name">Optional user-provided name for this snapshot.
        ///If the name is not provided in the request, the server will assign a random
        ///name for this snapshot on the same project as the subscription.
        ///Note that for REST API requests, you must specify a name.
        ///Format is `projects/{project}/snapshots/{snap}`.</param>
        Task<BaseResponse<Snapshot>> CreateAsync(string name, CreateSnapshotRequest CreateSnapshotRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Removes an existing snapshot. All messages retained in the snapshot
        ///are immediately dropped. After a snapshot is deleted, a new one may be
        ///created with the same name, but the new one has no association with the old
        ///snapshot or its subscription, unless the same subscription is specified.
        /// </summary>
        /// <param name="snapshot">The name of the snapshot to delete.
        ///Format is `projects/{project}/snapshots/{snap}`.</param>
        Task<BaseResponse<Empty>> DeleteAsync(string snapshot, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the configuration details of a snapshot.
        /// </summary>
        /// <param name="snapshot">The name of the snapshot to get.
        ///Format is `projects/{project}/snapshots/{snap}`.</param>
        Task<BaseResponse<Snapshot>> GetAsync(string snapshot, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the access control policy for a resource.
        ///Returns an empty policy if the resource exists and does not have a policy
        ///set.
        /// </summary>
        /// <param name="resource">REQUIRED: The resource for which the policy is being requested.
        ///See the operation documentation for the appropriate value for this field.</param>
        Task<BaseResponse<Policy>> GetIamPolicyAsync(string resource, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists the existing snapshots.
        /// </summary>
        /// <param name="project">The name of the cloud project that snapshots belong to.
        ///Format is `projects/{project}`.</param>
        /// <param name="pageToken">The value returned by the last `ListSnapshotsResponse`; indicates that this
        ///is a continuation of a prior `ListSnapshots` call, and that the system
        ///should return the next page of data.</param>
        /// <param name="pageSize">Maximum number of snapshots to return.</param>
        Task<BaseResponse<ListSnapshotsResponse>> ListAsync(string project, string pageToken, int? pageSize, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates an existing snapshot. Note that certain properties of a
        ///snapshot are not modifiable.
        /// </summary>
        /// <param name="name">The name of the snapshot.</param>
        Task<BaseResponse<Snapshot>> PatchAsync(string name, UpdateSnapshotRequest UpdateSnapshotRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sets the access control policy on the specified resource. Replaces any
        ///existing policy.
        /// </summary>
        /// <param name="resource">REQUIRED: The resource for which the policy is being specified.
        ///See the operation documentation for the appropriate value for this field.</param>
        Task<BaseResponse<Policy>> SetIamPolicyAsync(string resource, SetIamPolicyRequest SetIamPolicyRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns permissions that a caller has on the specified resource.
        ///If the resource does not exist, this will return an empty set of
        ///permissions, not a NOT_FOUND error.
        ///
        ///Note: This operation is designed to be used for building permission-aware
        ///UIs and command-line tools, not for authorization checking. This operation
        ///may "fail open" without warning.
        /// </summary>
        /// <param name="resource">REQUIRED: The resource for which the policy detail is being requested.
        ///See the operation documentation for the appropriate value for this field.</param>
        Task<BaseResponse<TestIamPermissionsResponse>> TestIamPermissionsAsync(string resource, TestIamPermissionsRequest TestIamPermissionsRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

    }
}