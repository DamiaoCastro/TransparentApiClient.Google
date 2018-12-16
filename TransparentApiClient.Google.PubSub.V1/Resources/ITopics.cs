using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;
using TransparentApiClient.Google.PubSub.V1.Schema;

namespace TransparentApiClient.Google.PubSub.V1.Resources {
    public interface ITopics {

        /// <summary>
        /// Creates the given topic with the given name.
        /// </summary>
        /// <param name="name">The name of the topic. It must have the format
        ///`"projects/{project}/topics/{topic}"`. `{topic}` must start with a letter,
        ///and contain only letters (`[A-Za-z]`), numbers (`[0-9]`), dashes (`-`),
        ///underscores (`_`), periods (`.`), tildes (`~`), plus (`+`) or percent
        ///signs (`%`). It must be between 3 and 255 characters in length, and it
        ///must not start with `"goog"`.</param>
        Task<BaseResponse<Topic>> CreateAsync(string name, Topic Topic, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the topic with the given name. Returns `NOT_FOUND` if the topic
        ///does not exist. After a topic is deleted, a new topic may be created with
        ///the same name; this is an entirely new topic with none of the old
        ///configuration or subscriptions. Existing subscriptions to this topic are
        ///not deleted, but their `topic` field is set to `_deleted-topic_`.
        /// </summary>
        /// <param name="topic">Name of the topic to delete.
        ///Format is `projects/{project}/topics/{topic}`.</param>
        Task<BaseResponse<Empty>> DeleteAsync(string topic, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the configuration of a topic.
        /// </summary>
        /// <param name="topic">The name of the topic to get.
        ///Format is `projects/{project}/topics/{topic}`.</param>
        Task<BaseResponse<Topic>> GetAsync(string topic, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the access control policy for a resource.
        ///Returns an empty policy if the resource exists and does not have a policy
        ///set.
        /// </summary>
        /// <param name="resource">REQUIRED: The resource for which the policy is being requested.
        ///See the operation documentation for the appropriate value for this field.</param>
        Task<BaseResponse<Policy>> GetIamPolicyAsync(string resource, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists matching topics.
        /// </summary>
        /// <param name="project">The name of the cloud project that topics belong to.
        ///Format is `projects/{project}`.</param>
        /// <param name="pageToken">The value returned by the last `ListTopicsResponse`; indicates that this is
        ///a continuation of a prior `ListTopics` call, and that the system should
        ///return the next page of data.</param>
        /// <param name="pageSize">Maximum number of topics to return.</param>
        Task<BaseResponse<ListTopicsResponse>> ListAsync(string project, string pageToken, int? pageSize, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Adds one or more messages to the topic. Returns `NOT_FOUND` if the topic
        ///does not exist. The message payload must not be empty; it must contain
        /// either a non-empty data field, or at least one attribute.
        /// </summary>
        /// <param name="topic">The messages in the request will be published on this topic.
        ///Format is `projects/{project}/topics/{topic}`.</param>
        Task<BaseResponse<PublishResponse>> PublishAsync(string topic, PublishRequest PublishRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

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