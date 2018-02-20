using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class SendAs { 

		/// <summary>
		/// A name that appears in the "From:" header for mail sent using this alias. For custom "from" addresses, when this is empty, Gmail will populate the "From:" header with the name that is used for the primary address associated with the account.
		/// </summary>
		public string displayName { get; set; }

		/// <summary>
		/// Whether this address is selected as the default "From:" address in situations such as composing a new message or sending a vacation auto-reply. Every Gmail account has exactly one default send-as address, so the only legal value that clients may write to this field is true. Changing this from false to true for an address will result in this field becoming false for the other previous default address.
		/// </summary>
		public bool isDefault { get; set; }

		/// <summary>
		/// Whether this address is the primary address used to login to the account. Every Gmail account has exactly one primary address, and it cannot be deleted from the collection of send-as aliases. This field is read-only.
		/// </summary>
		public bool isPrimary { get; set; }

		/// <summary>
		/// An optional email address that is included in a "Reply-To:" header for mail sent using this alias. If this is empty, Gmail will not generate a "Reply-To:" header.
		/// </summary>
		public string replyToAddress { get; set; }

		/// <summary>
		/// The email address that appears in the "From:" header for mail sent using this alias. This is read-only for all operations except create.
		/// </summary>
		public string sendAsEmail { get; set; }

		/// <summary>
		/// An optional HTML signature that is included in messages composed with this alias in the Gmail web UI.
		/// </summary>
		public string signature { get; set; }

		/// <summary>
		/// An optional SMTP service that will be used as an outbound relay for mail sent using this alias. If this is empty, outbound mail will be sent directly from Gmail's servers to the destination SMTP service. This setting only applies to custom "from" aliases.
		/// </summary>
		public SmtpMsa smtpMsa { get; set; }

		/// <summary>
		/// Whether Gmail should  treat this address as an alias for the user's primary email address. This setting only applies to custom "from" aliases.
		/// </summary>
		public bool treatAsAlias { get; set; }

		/// <summary>
		/// Indicates whether this address has been verified for use as a send-as alias. Read-only. This setting only applies to custom "from" aliases.
		/// </summary>
		public string verificationStatus { get; set; }

	}
}