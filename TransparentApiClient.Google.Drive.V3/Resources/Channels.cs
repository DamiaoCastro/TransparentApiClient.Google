using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Drive.V3.Resources { 

	public class Channels : BaseClient {

		public Channels(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/drive/v3/",
		    		new string[] {"https://www.googleapis.com/auth/drive","https://www.googleapis.com/auth/drive.appdata","https://www.googleapis.com/auth/drive.file","https://www.googleapis.com/auth/drive.metadata","https://www.googleapis.com/auth/drive.metadata.readonly","https://www.googleapis.com/auth/drive.photos.readonly","https://www.googleapis.com/auth/drive.readonly"}) {
		}

		/// <summary>
		/// Stop watching resources through this channel
		/// </summary>
		public Task<BaseResponse<object>> StopAsync(Schema.Channel Channel, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {

			return SendAsync(HttpMethod.Post, $"channels/stop", Channel, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

	}

}