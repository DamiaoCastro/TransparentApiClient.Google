using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class TableSchema { 

		/// <summary>
		/// Describes the fields in a table.
		/// </summary>
		public IEnumerable<TableFieldSchema> fields { get; set; }

	}
}