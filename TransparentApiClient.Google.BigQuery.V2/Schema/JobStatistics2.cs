using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class JobStatistics2 { 

		/// <summary>
		/// [Output-only] Billing tier for the job.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int billingTier { get; set; }

		/// <summary>
		/// [Output-only] Whether the query result was fetched from the query cache.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool cacheHit { get; set; }

		/// <summary>
		/// [Output-only, Experimental] The DDL operation performed, possibly dependent on the pre-existence of the DDL target. Possible values (new values might be added in the future): "CREATE": The query created the DDL target. "SKIP": No-op. Example cases: the query is CREATE TABLE IF NOT EXISTS while the table already exists, or the query is DROP TABLE IF EXISTS while the table does not exist. "REPLACE": The query replaced the DDL target. Example case: the query is CREATE OR REPLACE TABLE, and the table already exists. "DROP": The query deleted the DDL target.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string ddlOperationPerformed { get; set; }

		/// <summary>
		/// [Output-only, Experimental] The DDL target table. Present only for CREATE/DROP TABLE/VIEW queries.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public TableReference ddlTargetTable { get; set; }

		/// <summary>
		/// [Output-only] The original estimate of bytes processed for the job.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string estimatedBytesProcessed { get; set; }

		/// <summary>
		/// [Output-only] The number of rows affected by a DML statement. Present only for DML statements INSERT, UPDATE or DELETE.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string numDmlAffectedRows { get; set; }

		/// <summary>
		/// [Output-only] Describes execution plan for the query.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<ExplainQueryStage> queryPlan { get; set; }

		/// <summary>
		/// [Output-only] Referenced tables for the job. Queries that reference more than 50 tables will not have a complete list.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<TableReference> referencedTables { get; set; }

		/// <summary>
		/// [Output-only] The schema of the results. Present only for successful dry run of non-legacy SQL queries.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public TableSchema schema { get; set; }

		/// <summary>
		/// [Output-only, Experimental] The type of query statement, if valid. Possible values (new values might be added in the future): "SELECT": SELECT query. "INSERT": INSERT query; see https://cloud.google.com/bigquery/docs/reference/standard-sql/data-manipulation-language "UPDATE": UPDATE query; see https://cloud.google.com/bigquery/docs/reference/standard-sql/data-manipulation-language "DELETE": DELETE query; see https://cloud.google.com/bigquery/docs/reference/standard-sql/data-manipulation-language "CREATE_TABLE": CREATE [OR REPLACE] TABLE without AS SELECT. "CREATE_TABLE_AS_SELECT": CREATE [OR REPLACE] TABLE ... AS SELECT ... "DROP_TABLE": DROP TABLE query. "CREATE_VIEW": CREATE [OR REPLACE] VIEW ... AS SELECT ... "DROP_VIEW": DROP VIEW query.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string statementType { get; set; }

		/// <summary>
		/// [Output-only] [Experimental] Describes a timeline of job execution.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<QueryTimelineSample> timeline { get; set; }

		/// <summary>
		/// [Output-only] Total bytes billed for the job.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string totalBytesBilled { get; set; }

		/// <summary>
		/// [Output-only] Total bytes processed for the job.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string totalBytesProcessed { get; set; }

		/// <summary>
		/// [Output-only] Total number of partitions processed from all partitioned tables referenced in the job.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string totalPartitionsProcessed { get; set; }

		/// <summary>
		/// [Output-only] Slot-milliseconds for the job.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string totalSlotMs { get; set; }

		/// <summary>
		/// [Output-only, Experimental] Standard SQL only: list of undeclared query parameters detected during a dry run validation.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<QueryParameter> undeclaredQueryParameters { get; set; }

	}
}