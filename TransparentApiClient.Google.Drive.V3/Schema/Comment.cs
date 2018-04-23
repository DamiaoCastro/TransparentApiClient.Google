using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class Comment { 

		/// <summary>
		/// A region of the document represented as a JSON string. See anchor documentation for details on how to define and interpret anchor properties.
		/// </summary>
		public string anchor { get; set; }

		/// <summary>
		/// The user who created the comment.
		/// </summary>
		public User author { get; set; }

		/// <summary>
		/// The plain text content of the comment. This field is used for setting the content, while htmlContent should be displayed.
		/// </summary>
		public string content { get; set; }

		/// <summary>
		/// The time at which the comment was created (RFC 3339 date-time).
		/// </summary>
		public string createdTime { get; set; }

		/// <summary>
		/// Whether the comment has been deleted. A deleted comment has no content.
		/// </summary>
		public bool deleted { get; set; }

		/// <summary>
		/// The content of the comment with HTML formatting.
		/// </summary>
		public string htmlContent { get; set; }

		/// <summary>
		/// The ID of the comment.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#comment".
		/// </summary>
		public string kind { get; set; } = "drive#comment";

		/// <summary>
		/// The last time the comment or any of its replies was modified (RFC 3339 date-time).
		/// </summary>
		public string modifiedTime { get; set; }

		/// <summary>
		/// The file content to which the comment refers, typically within the anchor region. For a text file, for example, this would be the text at the location of the comment.
		/// </summary>
		public object quotedFileContent { get; set; }

		/// <summary>
		/// The full list of replies to the comment in chronological order.
		/// </summary>
		public IEnumerable<Reply> replies { get; set; }

		/// <summary>
		/// Whether the comment has been resolved by one of its replies.
		/// </summary>
		public bool resolved { get; set; }

	}
}