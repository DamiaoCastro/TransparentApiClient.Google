using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class DatasetList { 

		/// <summary>
		/// An array of the dataset resources in the project. Each resource contains basic information. For full information about a particular dataset resource, use the Datasets: get method. This property is omitted when there are no datasets in the project.
		/// </summary>
		public IEnumerable<Dataset> datasets { get; set; }

		/// <summary>
		/// A hash value of the results page. You can use this property to determine if the page has changed since the last request.
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// The list type. This property always returns the value "bigquery#datasetList".
		/// </summary>
		public string kind { get; set; } = "bigquery#datasetList";

		/// <summary>
		/// A token that can be used to request the next results page. This property is omitted on the final results page.
		/// </summary>
		public string nextPageToken { get; set; }

	public class Dataset { 

		/// <summary>
		/// The dataset reference. Use this property to access specific parts of the dataset's ID, such as project ID or dataset ID.
		/// </summary>
		public DatasetReference datasetReference { get; set; }

		/// <summary>
		/// A descriptive name for the dataset, if one exists.
		/// </summary>
		public string friendlyName { get; set; }

		/// <summary>
		/// The fully-qualified, unique, opaque ID of the dataset.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The resource type. This property always returns the value "bigquery#dataset".
		/// </summary>
		public string kind { get; set; } = "bigquery#dataset";

		/// <summary>
		/// The labels associated with this dataset. You can use these to organize and group your datasets.
		/// </summary>
		public object labels { get; set; }

		/// <summary>
		/// [Experimental] The geographic location where the data resides.
		/// </summary>
		public string location { get; set; }

	}
	}
}