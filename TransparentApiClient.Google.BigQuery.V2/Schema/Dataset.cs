using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class Dataset { 
 /// <summary>
/// [Optional] An array of objects that define dataset access for one or more entities. You can set this property when inserting or updating a dataset in order to control who is allowed to access the data. If unspecified at dataset creation time, BigQuery adds default dataset access for the following entities: access.specialGroup: projectReaders; access.role: READER; access.specialGroup: projectWriters; access.role: WRITER; access.specialGroup: projectOwners; access.role: OWNER; access.userByEmail: [dataset creator email]; access.role: OWNER;
/// </summary>
public IEnumerable<object> access { get; set; }
/// <summary>
/// [Output-only] The time when this dataset was created, in milliseconds since the epoch.
/// </summary>
public string creationTime { get; set; }
/// <summary>
/// [Required] A reference that identifies the dataset.
/// </summary>
public object datasetReference { get; set; }
/// <summary>
/// [Optional] The default lifetime of all tables in the dataset, in milliseconds. The minimum value is 3600000 milliseconds (one hour). Once this property is set, all newly-created tables in the dataset will have an expirationTime property set to the creation time plus the value in this property, and changing the value will only affect new tables, not existing ones. When the expirationTime for a given table is reached, that table will be deleted automatically. If a table's expirationTime is modified or removed before the table expires, or if you provide an explicit expirationTime when creating a table, that value takes precedence over the default expiration time indicated by this property.
/// </summary>
public string defaultTableExpirationMs { get; set; }
/// <summary>
/// [Optional] A user-friendly description of the dataset.
/// </summary>
public string description { get; set; }
/// <summary>
/// [Output-only] A hash of the resource.
/// </summary>
public string etag { get; set; }
/// <summary>
/// [Optional] A descriptive name for the dataset.
/// </summary>
public string friendlyName { get; set; }
/// <summary>
/// [Output-only] The fully-qualified unique name of the dataset in the format projectId:datasetId. The dataset name without the project name is given in the datasetId field. When creating a new dataset, leave this field blank, and instead specify the datasetId field.
/// </summary>
public string id { get; set; }
/// <summary>
/// [Output-only] The resource type.
/// </summary>
public string kind { get; set; }
/// <summary>
/// The labels associated with this dataset. You can use these to organize and group your datasets. You can set this property when inserting or updating a dataset. See Labeling Datasets for more information.
/// </summary>
public object labels { get; set; }
/// <summary>
/// [Output-only] The date when this dataset or any of its tables was last modified, in milliseconds since the epoch.
/// </summary>
public string lastModifiedTime { get; set; }
/// <summary>
/// The geographic location where the dataset should reside. Possible values include EU and US. The default value is US.
/// </summary>
public string location { get; set; }
/// <summary>
/// [Output-only] A URL that can be used to access the resource again. You can use this URL in Get or Update requests to the resource.
/// </summary>
public string selfLink { get; set; }

} 
}
