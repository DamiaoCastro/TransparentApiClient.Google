using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class ExplainQueryStage { 
 /// <summary>
/// Number of parallel input segments completed.
/// </summary>
public string completedParallelInputs { get; set; }
/// <summary>
/// Milliseconds the average shard spent on CPU-bound tasks.
/// </summary>
public string computeMsAvg { get; set; }
/// <summary>
/// Milliseconds the slowest shard spent on CPU-bound tasks.
/// </summary>
public string computeMsMax { get; set; }
/// <summary>
/// Relative amount of time the average shard spent on CPU-bound tasks.
/// </summary>
public double computeRatioAvg { get; set; }
/// <summary>
/// Relative amount of time the slowest shard spent on CPU-bound tasks.
/// </summary>
public double computeRatioMax { get; set; }
/// <summary>
/// Stage end time in milliseconds.
/// </summary>
public string endMs { get; set; }
/// <summary>
/// Unique ID for stage within plan.
/// </summary>
public string id { get; set; }
/// <summary>
/// IDs for stages that are inputs to this stage.
/// </summary>
public IEnumerable<object> inputStages { get; set; }
/// <summary>
/// Human-readable name for stage.
/// </summary>
public string name { get; set; }
/// <summary>
/// Number of parallel input segments to be processed.
/// </summary>
public string parallelInputs { get; set; }
/// <summary>
/// Milliseconds the average shard spent reading input.
/// </summary>
public string readMsAvg { get; set; }
/// <summary>
/// Milliseconds the slowest shard spent reading input.
/// </summary>
public string readMsMax { get; set; }
/// <summary>
/// Relative amount of time the average shard spent reading input.
/// </summary>
public double readRatioAvg { get; set; }
/// <summary>
/// Relative amount of time the slowest shard spent reading input.
/// </summary>
public double readRatioMax { get; set; }
/// <summary>
/// Number of records read into the stage.
/// </summary>
public string recordsRead { get; set; }
/// <summary>
/// Number of records written by the stage.
/// </summary>
public string recordsWritten { get; set; }
/// <summary>
/// Total number of bytes written to shuffle.
/// </summary>
public string shuffleOutputBytes { get; set; }
/// <summary>
/// Total number of bytes written to shuffle and spilled to disk.
/// </summary>
public string shuffleOutputBytesSpilled { get; set; }
/// <summary>
/// Stage start time in milliseconds.
/// </summary>
public string startMs { get; set; }
/// <summary>
/// Current status for the stage.
/// </summary>
public string status { get; set; }
/// <summary>
/// List of operations within the stage in dependency order (approximately chronological).
/// </summary>
public IEnumerable<object> steps { get; set; }
/// <summary>
/// Milliseconds the average shard spent waiting to be scheduled.
/// </summary>
public string waitMsAvg { get; set; }
/// <summary>
/// Milliseconds the slowest shard spent waiting to be scheduled.
/// </summary>
public string waitMsMax { get; set; }
/// <summary>
/// Relative amount of time the average shard spent waiting to be scheduled.
/// </summary>
public double waitRatioAvg { get; set; }
/// <summary>
/// Relative amount of time the slowest shard spent waiting to be scheduled.
/// </summary>
public double waitRatioMax { get; set; }
/// <summary>
/// Milliseconds the average shard spent on writing output.
/// </summary>
public string writeMsAvg { get; set; }
/// <summary>
/// Milliseconds the slowest shard spent on writing output.
/// </summary>
public string writeMsMax { get; set; }
/// <summary>
/// Relative amount of time the average shard spent on writing output.
/// </summary>
public double writeRatioAvg { get; set; }
/// <summary>
/// Relative amount of time the slowest shard spent on writing output.
/// </summary>
public double writeRatioMax { get; set; }

} 
}
