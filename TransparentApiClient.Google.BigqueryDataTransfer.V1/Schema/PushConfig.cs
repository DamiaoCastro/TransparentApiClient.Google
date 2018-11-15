using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigqueryDataTransfer.V1.Schema { 
	public class PushConfig { 

		/// <summary>
		/// A URL locating the endpoint to which messages should be pushed.
		///For example, a Webhook endpoint might use "https://example.com/push".
		/// </summary>
		public string pushEndpoint { get; set; }

		/// <summary>
		/// Endpoint configuration attributes.
		///
		///Every endpoint has a set of API supported attributes that can be used to
		///control different aspects of the message delivery.
		///
		///The currently supported attribute is `x-goog-version`, which you can
		///use to change the format of the pushed message. This attribute
		///indicates the version of the data expected by the endpoint. This
		///controls the shape of the pushed message (i.e., its fields and metadata).
		///The endpoint version is based on the version of the Pub/Sub API.
		///
		///If not present during the `CreateSubscription` call, it will default to
		///the version of the API used to make such call. If not present during a
		///`ModifyPushConfig` call, its value will not be changed. `GetSubscription`
		///calls will always return a valid version, even if the subscription was
		///created without this attribute.
		///
		///The possible values for this attribute are:
		///
		///* `v1beta1`: uses the push format defined in the v1beta1 Pub/Sub API.
		///* `v1` or `v1beta2`: uses the push format defined in the v1 Pub/Sub API.
		/// </summary>
		public object attributes { get; set; }

	}
}