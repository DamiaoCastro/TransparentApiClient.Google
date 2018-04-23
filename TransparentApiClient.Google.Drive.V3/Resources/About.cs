using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Drive.V3.Resources { 

	public class About : BaseClient {

		public About(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/drive/v3/",
		    		new string[] {"https://www.googleapis.com/auth/drive","https://www.googleapis.com/auth/drive.appdata","https://www.googleapis.com/auth/drive.file","https://www.googleapis.com/auth/drive.metadata","https://www.googleapis.com/auth/drive.metadata.readonly","https://www.googleapis.com/auth/drive.photos.readonly","https://www.googleapis.com/auth/drive.readonly"}) {
		}

		/// <summary>
		/// Gets information about the user, the user's Drive, and system capabilities.
		/// </summary>
		public Task<BaseResponse<Schema.About>> GetAsync(JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {

			return SendAsync(HttpMethod.Get, $"about", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.About>, cancellationToken)
				.Unwrap();
		}

	}

}