using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class ViewDefinition { 

		/// <summary>
		/// [Required] A query that BigQuery executes when the view is referenced.
		/// </summary>
		public string query { get; set; }

		/// <summary>
		/// Specifies whether to use BigQuery's legacy SQL for this view. The default value is true. If set to false, the view will use BigQuery's standard SQL: https://cloud.google.com/bigquery/sql-reference/ Queries and views that reference this view must use the same flag value.
		/// </summary>
		public bool useLegacySql { get; set; }

		/// <summary>
		/// Describes user-defined function resources used in the query.
		/// </summary>
		public IEnumerable<UserDefinedFunctionResource> userDefinedFunctionResources { get; set; }

	}
}