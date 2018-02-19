using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class ProjectList { 

		/// <summary>
		/// A hash of the page of results
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// The type of list.
		/// </summary>
		public string kind { get; set; } = "bigquery#projectList";

		/// <summary>
		/// A token to request the next page of results.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// Projects to which you have at least READ access.
		/// </summary>
		public IEnumerable<Project> projects { get; set; }

		/// <summary>
		/// The total number of projects in the list.
		/// </summary>
		public int totalItems { get; set; }

	public class Project { 

		/// <summary>
		/// A descriptive name for this project.
		/// </summary>
		public string friendlyName { get; set; }

		/// <summary>
		/// An opaque ID of this project.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The resource type.
		/// </summary>
		public string kind { get; set; } = "bigquery#project";

		/// <summary>
		/// The numeric ID of this project.
		/// </summary>
		public string numericId { get; set; }

		/// <summary>
		/// A unique reference to this project.
		/// </summary>
		public ProjectReference projectReference { get; set; }

	}
	}
}