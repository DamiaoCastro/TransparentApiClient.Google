using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class TableRow { 

		/// <summary>
		/// Represents a single row in the result set, consisting of one or more fields.
		/// </summary>
		public IEnumerable<TableCell> f { get; set; }

	}
}