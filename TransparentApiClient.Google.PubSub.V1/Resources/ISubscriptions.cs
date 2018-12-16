using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;
using TransparentApiClient.Google.PubSub.V1.Schema;

namespace TransparentApiClient.Google.PubSub.V1.Resources {
    public interface ISubscriptions {

        /// <summary>
        /// Acknowledges the messages associated with the `ack_ids` in the
        ///`AcknowledgeRequest`. The Pub/Sub system can remove the relevant messages
        ///from the subscription.
        ///
        ///Acknowledging a message whose ack deadline has expired may succeed,
        ///but such a message may be redelivered later. Acknowledging a message more
        ///than once will not result in an error.
        /// </summary>
        /// <param name="subscription">The subscription whose message is being acknowledged.
        ///Format is `projects/{project}/subscriptions/{sub}`.</param>
        Task<BaseResponse<Empty>> AcknowledgeAsync(string subscription, AcknowledgeRequest AcknowledgeRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a subscription to a given topic.
        ///If the subscription already exists, returns `ALREADY_EXISTS`.
        ///If the corresponding topic doesn't exist, returns `NOT_FOUND`.
        ///
        ///If the name is not provided in the request, the server will assign a random
        ///name for this subscription on the same project as the topic, conforming
        ///to the
        ///[resource name format](https://cloud.google.com/pubsub/docs/overview#names).
        ///The generated name is populated in the returned Subscription object.
        ///Note that for REST API requests, you must specify a name in the request.
        /// </summary>
        /// <param name="name">The name of the subscription. It must have the format
        ///`"projects/{project}/subscriptions/{subscription}"`. `{subscription}` must
        ///start with a letter, and contain only letters (`[A-Za-z]`), numbers
        ///(`[0-9]`), dashes (`-`), underscores (`_`), periods (`.`), tildes (`~`),
        ///plus (`+`) or percent signs (`%`). It must be between 3 and 255 characters
        ///in length, and it must not start with `"goog"`.</param>
        Task<BaseResponse<Subscription>> CreateAsync(string name, Subscription Subscription, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes an existing subscription. All messages retained in the subscription
        ///are immediately dropped. Calls to `Pull` after deletion will return
        ///`NOT_FOUND`. After a subscription is deleted, a new one may be created with
        ///the same name, but the new one has no association with the old
        ///subscription or its topic unless the same topic is specified.
        /// </summary>
        /// <param name="subscription">The subscription to delete.
        ///Format is `projects/{project}/subscriptions/{sub}`.</param>
        Task<BaseResponse<Empty>> DeleteAsync(string subscription, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the configuration details of a subscription.
        /// </summary>
        /// <param name="subscription">The name of the subscription to get.
        ///Format is `projects/{project}/subscriptions/{sub}`.</param>
        Task<BaseResponse<Subscription>> GetAsync(string subscription, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the access control policy for a resource.
        ///Returns an empty policy if the resource exists and does not have a policy
        ///set.
        /// </summary>
        /// <param name="resource">REQUIRED: The resource for which the policy is being requested.
        ///See the operation documentation for the appropriate value for this field.</param>
        Task<BaseResponse<Policy>> GetIamPolicyAsync(string resource, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists matching subscriptions.
        /// </summary>
        /// <param name="project">The name of the cloud project that subscriptions belong to.
        ///Format is `projects/{project}`.</param>
        /// <param name="pageToken">The value returned by the last `ListSubscriptionsResponse`; indicates that
        ///this is a continuation of a prior `ListSubscriptions` call, and that the
        ///system should return the next page of data.</param>
        /// <param name="pageSize">Maximum number of subscriptions to return.</param>
        Task<BaseResponse<ListSubscriptionsResponse>> ListAsync(string project, string pageToken, int? pageSize, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Modifies the ack deadline for a specific message. This method is useful
        ///to indicate that more time is needed to process a message by the
        ///subscriber, or to make the message available for redelivery if the
        ///processing was interrupted. Note that this does not modify the
        ///subscription-level `ackDeadlineSeconds` used for subsequent messages.
        /// </summary>
        /// <param name="subscription">The name of the subscription.
        ///Format is `projects/{project}/subscriptions/{sub}`.</param>
        Task<BaseResponse<Empty>> ModifyAckDeadlineAsync(string subscription, ModifyAckDeadlineRequest ModifyAckDeadlineRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Modifies the `PushConfig` for a specified subscription.
        ///
        ///This may be used to change a push subscription to a pull one (signified by
        ///an empty `PushConfig`) or vice versa, or change the endpoint URL and other
        ///attributes of a push subscription. Messages will accumulate for delivery
        ///continuously through the call regardless of changes to the `PushConfig`.
        /// </summary>
        /// <param name="subscription">The name of the subscription.
        ///Format is `projects/{project}/subscriptions/{sub}`.</param>
        Task<BaseResponse<Empty>> ModifyPushConfigAsync(string subscription, ModifyPushConfigRequest ModifyPushConfigRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates an existing subscription. Note that certain properties of a
        ///subscription, such as its topic, are not modifiable.
        /// </summary>
        /// <param name="name">The name of the subscription. It must have the format
        ///`"projects/{project}/subscriptions/{subscription}"`. `{subscription}` must
        ///start with a letter, and contain only letters (`[A-Za-z]`), numbers
        ///(`[0-9]`), dashes (`-`), underscores (`_`), periods (`.`), tildes (`~`),
        ///plus (`+`) or percent signs (`%`). It must be between 3 and 255 characters
        ///in length, and it must not start with `"goog"`.</param>
        Task<BaseResponse<Subscription>> PatchAsync(string name, UpdateSubscriptionRequest UpdateSubscriptionRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Pulls messages from the server. Returns an empty list if there are no
        ///messages available in the backlog. The server may return `UNAVAILABLE` if
        ///there are too many concurrent pull requests pending for the given
        ///subscription.
        /// </summary>
        /// <param name="subscription">The subscription from which messages should be pulled.
        ///Format is `projects/{project}/subscriptions/{sub}`.</param>
        Task<BaseResponse<PullResponse>> PullAsync(string subscription, PullRequest PullRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Seeks an existing subscription to a point in time or to a given snapshot,
        ///whichever is provided in the request.
        /// </summary>
        /// <param name="subscription">The subscription to affect.</param>
        Task<BaseResponse<SeekResponse>> SeekAsync(string subscription, SeekRequest SeekRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken));

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