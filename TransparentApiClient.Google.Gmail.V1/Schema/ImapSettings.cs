using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ImapSettings { 

		/// <summary>
		/// If this value is true, Gmail will immediately expunge a message when it is marked as deleted in IMAP. Otherwise, Gmail will wait for an update from the client before expunging messages marked as deleted.
		/// </summary>
		public bool autoExpunge { get; set; }

		/// <summary>
		/// Whether IMAP is enabled for the account.
		/// </summary>
		public bool enabled { get; set; }

		/// <summary>
		/// The action that will be executed on a message when it is marked as deleted and expunged from the last visible IMAP folder.
		/// </summary>
		public string expungeBehavior { get; set; }

		/// <summary>
		/// An optional limit on the number of messages that an IMAP folder may contain. Legal values are 0, 1000, 2000, 5000 or 10000. A value of zero is interpreted to mean that there is no limit.
		/// </summary>
		public int maxFolderSize { get; set; }

	}
}