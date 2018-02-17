using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class TableList { 

		/// <summary>
		/// A hash of this page of results.
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// The type of list.
		/// </summary>
		public string kind { get; set; } = "bigquery#tableList";

		/// <summary>
		/// A token to request the next page of results.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// Tables in the requested dataset.
		/// </summary>
		public IEnumerable<Table> tables { get; set; }

		/// <summary>
		/// The total number of tables in the dataset.
		/// </summary>
		public int totalItems { get; set; }

	public class Table { 

		/// <summary>
		/// The time when this table was created, in milliseconds since the epoch.
		/// </summary>
		public string creationTime { get; set; }

		/// <summary>
		/// [Optional] The time when this table expires, in milliseconds since the epoch. If not present, the table will persist indefinitely. Expired tables will be deleted and their storage reclaimed.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string expirationTime { get; set; }

		/// <summary>
		/// The user-friendly name for this table.
		/// </summary>
		public string friendlyName { get; set; }

		/// <summary>
		/// An opaque ID of the table
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The resource type.
		/// </summary>
		public string kind { get; set; } = "bigquery#table";

		/// <summary>
		/// The labels associated with this table. You can use these to organize and group your tables.
		/// </summary>
		public object labels { get; set; }

		/// <summary>
		/// A reference uniquely identifying the table.
		/// </summary>
		public object tableReference { get; set; }

		/// <summary>
		/// The time-based partitioning for this table.
		/// </summary>
		public object timePartitioning { get; set; }

		/// <summary>
		/// The type of table. Possible values are: TABLE, VIEW.
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// Additional details for a view.
		/// </summary>
		public object view { get; set; }

	}
	}
}