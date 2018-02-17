using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class TableDataInsertAllResponse { 

		/// <summary>
		/// An array of errors for rows that were not inserted.
		/// </summary>
		public IEnumerable<InsertError> insertErrors { get; set; }

		/// <summary>
		/// The resource type of the response.
		/// </summary>
		public string kind { get; set; } = "bigquery#tableDataInsertAllResponse";

	public class InsertError { 

		/// <summary>
		/// Error information for the row indicated by the index property.
		/// </summary>
		public IEnumerable<ErrorProto> errors { get; set; }

		/// <summary>
		/// The index of the row that error applies to.
		/// </summary>
		public int index { get; set; }

	}
	}
}