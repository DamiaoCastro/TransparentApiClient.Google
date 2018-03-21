using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class Subscription { 

		/// <summary>
		/// How long to retain unacknowledged messages in the subscription's backlog,
		///from the moment a message is published.
		///If `retain_acked_messages` is true, then this also configures the retention
		///of acknowledged messages, and thus configures how far back in time a `Seek`
		///can be done. Defaults to 7 days. Cannot be more than 7 days or less than 10
		///minutes.
		/// </summary>
		public string messageRetentionDuration { get; set; }

		/// <summary>
		/// Indicates whether to retain acknowledged messages. If true, then
		///messages are not expunged from the subscription's backlog, even if they are
		///acknowledged, until they fall out of the `message_retention_duration`
		///window.
		/// </summary>
		public bool retainAckedMessages { get; set; }

		/// <summary>
		/// The name of the subscription. It must have the format
		///`"projects/{project}/subscriptions/{subscription}"`. `{subscription}` must
		///start with a letter, and contain only letters (`[A-Za-z]`), numbers
		///(`[0-9]`), dashes (`-`), underscores (`_`), periods (`.`), tildes (`~`),
		///plus (`+`) or percent signs (`%`). It must be between 3 and 255 characters
		///in length, and it must not start with `"goog"`.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The name of the topic from which this subscription is receiving messages.
		///Format is `projects/{project}/topics/{topic}`.
		///The value of this field will be `_deleted-topic_` if the topic has been
		///deleted.
		/// </summary>
		public string topic { get; set; }

		/// <summary>
		/// If push delivery is used with this subscription, this field is
		///used to configure it. An empty `pushConfig` signifies that the subscriber
		///will pull and ack messages using API methods.
		/// </summary>
		public PushConfig pushConfig { get; set; }

		/// <summary>
		/// This value is the maximum time after a subscriber receives a message
		///before the subscriber should acknowledge the message. After message
		///delivery but before the ack deadline expires and before the message is
		///acknowledged, it is an outstanding message and will not be delivered
		///again during that time (on a best-effort basis).
		///
		///For pull subscriptions, this value is used as the initial value for the ack
		///deadline. To override this value for a given message, call
		///`ModifyAckDeadline` with the corresponding `ack_id` if using
		///non-streaming pull or send the `ack_id` in a
		///`StreamingModifyAckDeadlineRequest` if using streaming pull.
		///The minimum custom deadline you can specify is 10 seconds.
		///The maximum custom deadline you can specify is 600 seconds (10 minutes).
		///If this parameter is 0, a default value of 10 seconds is used.
		///
		///For push delivery, this value is also used to set the request timeout for
		///the call to the push endpoint.
		///
		///If the subscriber never acknowledges the message, the Pub/Sub
		///system will eventually redeliver the message.
		/// </summary>
		public int ackDeadlineSeconds { get; set; }

	}
}