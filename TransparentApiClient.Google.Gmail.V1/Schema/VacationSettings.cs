using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class VacationSettings { 

		/// <summary>
		/// Flag that controls whether Gmail automatically replies to messages.
		/// </summary>
		public bool enableAutoReply { get; set; }

		/// <summary>
		/// An optional end time for sending auto-replies (epoch ms). When this is specified, Gmail will automatically reply only to messages that it receives before the end time. If both startTime and endTime are specified, startTime must precede endTime.
		/// </summary>
		public string endTime { get; set; }

		/// <summary>
		/// Response body in HTML format. Gmail will sanitize the HTML before storing it.
		/// </summary>
		public string responseBodyHtml { get; set; }

		/// <summary>
		/// Response body in plain text format.
		/// </summary>
		public string responseBodyPlainText { get; set; }

		/// <summary>
		/// Optional text to prepend to the subject line in vacation responses. In order to enable auto-replies, either the response subject or the response body must be nonempty.
		/// </summary>
		public string responseSubject { get; set; }

		/// <summary>
		/// Flag that determines whether responses are sent to recipients who are not in the user's list of contacts.
		/// </summary>
		public bool restrictToContacts { get; set; }

		/// <summary>
		/// Flag that determines whether responses are sent to recipients who are outside of the user's domain. This feature is only available for G Suite users.
		/// </summary>
		public bool restrictToDomain { get; set; }

		/// <summary>
		/// An optional start time for sending auto-replies (epoch ms). When this is specified, Gmail will automatically reply only to messages that it receives after the start time. If both startTime and endTime are specified, startTime must precede endTime.
		/// </summary>
		public string startTime { get; set; }

	}
}