using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class SmimeInfo { 

		/// <summary>
		/// Encrypted key password, when key is encrypted.
		/// </summary>
		public string encryptedKeyPassword { get; set; }

		/// <summary>
		/// When the certificate expires (in milliseconds since epoch).
		/// </summary>
		public string expiration { get; set; }

		/// <summary>
		/// The immutable ID for the SmimeInfo.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Whether this SmimeInfo is the default one for this user's send-as address.
		/// </summary>
		public bool isDefault { get; set; }

		/// <summary>
		/// The S/MIME certificate issuer's common name.
		/// </summary>
		public string issuerCn { get; set; }

		/// <summary>
		/// PEM formatted X509 concatenated certificate string (standard base64 encoding). Format used for returning key, which includes public key as well as certificate chain (not private key).
		/// </summary>
		public string pem { get; set; }

		/// <summary>
		/// PKCS#12 format containing a single private/public key pair and certificate chain. This format is only accepted from client for creating a new SmimeInfo and is never returned, because the private key is not intended to be exported. PKCS#12 may be encrypted, in which case encryptedKeyPassword should be set appropriately.
		/// </summary>
		public string pkcs12 { get; set; }

	}
}