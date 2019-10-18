using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class CloudFunction { 

		/// <summary>
		/// The Google Cloud Storage URL, starting with gs://, pointing to the zip
		///archive which contains the function.
		/// </summary>
		public string sourceArchiveUrl { get; set; }

		/// <summary>
		/// **Beta Feature**
		///
		///The source repository where a function is hosted.
		/// </summary>
		public SourceRepository sourceRepository { get; set; }

		/// <summary>
		/// The VPC Network that this cloud function can connect to. It can be
		///either the fully-qualified URI, or the short name of the network resource.
		///If the short network name is used, the network must belong to the same
		///project. Otherwise, it must belong to a project within the same
		///organization. The format of this field is either
		///`projects/{project}/global/networks/{network}` or `{network}`, where
		///{project} is a project id where the network is defined, and {network} is
		///the short name of the network.
		///
		///This field is mutually exclusive with `vpc_connector` and will be replaced
		///by it.
		///
		///See [the VPC documentation](https://cloud.google.com/compute/docs/vpc) for
		///more information on connecting Cloud projects.
		/// </summary>
		public string network { get; set; }

		/// <summary>
		/// The VPC Network Connector that this cloud function can connect to. It can
		///be either the fully-qualified URI, or the short name of the network
		///connector resource. The format of this field is
		///`projects/*/locations/*/connectors/*`
		///
		///This field is mutually exclusive with `network` field and will eventually
		///replace it.
		///
		///See [the VPC documentation](https://cloud.google.com/compute/docs/vpc) for
		///more information on connecting Cloud projects.
		/// </summary>
		public string vpcConnector { get; set; }

		/// <summary>
		/// Labels associated with this Cloud Function.
		/// </summary>
		public object labels { get; set; }

		/// <summary>
		/// The name of the function (as defined in source code) that will be
		///executed. Defaults to the resource name suffix, if not specified. For
		///backward compatibility, if function with given name is not found, then the
		///system will try to use function named "function".
		///For Node.js this is name of a function exported by the module specified
		///in `source_location`.
		/// </summary>
		public string entryPoint { get; set; }

		/// <summary>
		/// Output only. The last update timestamp of a Cloud Function.
		/// </summary>
		public string updateTime { get; set; }

		/// <summary>
		/// An HTTPS endpoint type of source that can be triggered via URL.
		/// </summary>
		public HttpsTrigger httpsTrigger { get; set; }

		/// <summary>
		/// The email of the function's service account. If empty, defaults to
		///`{project_id}@appspot.gserviceaccount.com`.
		/// </summary>
		public string serviceAccountEmail { get; set; }

		/// <summary>
		/// The limit on the maximum number of function instances that may coexist at a
		///given time.
		/// </summary>
		public int maxInstances { get; set; }

		/// <summary>
		/// User-provided description of a function.
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Environment variables that shall be available during function execution.
		/// </summary>
		public object environmentVariables { get; set; }

		/// <summary>
		/// The function execution timeout. Execution is considered failed and
		///can be terminated if the function is not completed at the end of the
		///timeout period. Defaults to 60 seconds.
		/// </summary>
		public string timeout { get; set; }

		/// <summary>
		/// Output only. Status of the function deployment.
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// A source that fires events in response to a condition in another service.
		/// </summary>
		public EventTrigger eventTrigger { get; set; }

		/// <summary>
		/// The Google Cloud Storage signed URL used for source uploading, generated
		///by google.cloud.functions.v1.GenerateUploadUrl
		/// </summary>
		public string sourceUploadUrl { get; set; }

		/// <summary>
		/// The amount of memory in MB available for a function.
		///Defaults to 256MB.
		/// </summary>
		public int availableMemoryMb { get; set; }

		/// <summary>
		/// The runtime in which to run the function. Required when deploying a new
		///function, optional when updating an existing function. For a complete
		///list of possible choices, see the
		///[`gcloud` command
		///reference](/sdk/gcloud/reference/functions/deploy#--runtime).
		/// </summary>
		public string runtime { get; set; }

		/// <summary>
		/// A user-defined name of the function. Function names must be unique
		///globally and match pattern `projects/*/locations/*/functions/*`
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Output only. The version identifier of the Cloud Function. Each deployment attempt
		///results in a new version of a function being created.
		/// </summary>
		public string versionId { get; set; }

	}
}