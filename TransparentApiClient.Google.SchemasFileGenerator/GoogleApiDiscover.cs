﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TransparentApiClient.Google.SchemasFileGenerator {

    internal class GoogleApiDiscover {
        public string kind { get; set; }
        public string etag { get; set; }
        public string discoveryVersion { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string version { get; set; }
        public string revision { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string ownerDomain { get; set; }
        public string ownerName { get; set; }
        public Icons icons { get; set; }
        public string documentationLink { get; set; }
        public string protocol { get; set; }
        public string baseUrl { get; set; }
        public string basePath { get; set; }
        public string rootUrl { get; set; }
        public string servicePath { get; set; }
        public string batchPath { get; set; }
        public Dictionary<string, JObject> parameters { get; set; }
        public JObject auth { get; set; }
        public Dictionary<string, GoogleApiDiscoverSchema> schemas { get; set; }
        public Dictionary<string, GoogleApiDiscoverResource> resources { get; set; }
    }

    internal class Icons {
        public string x16 { get; set; }
        public string x32 { get; set; }
    }

    internal class GoogleApiDiscoverSchema {
        public string id { get; set; }
        public string type { get; set; }
        [JsonProperty("$ref")]
        public string refName { get; set; }
        public string description { get; set; }
        public string @default { get; set; }
        public bool required { get; set; }
        public string format { get; set; }
        public string pattern { get; set; }
        public string minimum { get; set; }
        public string maximum { get; set; }
        public IEnumerable<string> @enum { get; set; }
        public IEnumerable<string> enumDescriptions { get; set; }
        public bool repeated { get; set; }
        public string location { get; set; }

        public Dictionary<string, GoogleApiDiscoverSchema> properties { get; set; }
        public GoogleApiDiscoverSchema additionalProperties { get; set; }
        public GoogleApiDiscoverSchema items { get; set; }
        public GoogleApiDiscoverSchemaPropertyAnnotations annotations { get; set; }
    }
    
    internal class GoogleApiDiscoverSchemaPropertyAnnotations {
        public IEnumerable<string> required { get; set; }
    }

    internal class GoogleApiDiscoverResource {
        public Dictionary<string, GoogleApiDiscoverMethod> methods { get; set; }
        public Dictionary<string, GoogleApiDiscoverResource> resources { get; set; }
    }

    internal class GoogleApiDiscoverMethod {
        public string id { get; set; }
        public string path { get; set; }
        public string flatPath { get; set; }
        public string httpMethod { get; set; }
        public string description { get; set; }
        public Dictionary<string, GoogleApiDiscoverMethodParameter> parameters { get; set; }
        public string[] parameterOrder { get; set; }
        public GoogleApiDiscoverMethodRequestResponse request { get; set; }
        public GoogleApiDiscoverMethodRequestResponse response { get; set; }
        public string[] scopes { get; set; }
    }

    internal class GoogleApiDiscoverMethodRequestResponse {
        [JsonProperty("$ref")]
        public string refName { get; set; }
    }

    internal class GoogleApiDiscoverMethodParameter {
        public string type { get; set; }
        public string description { get; set; }
        public bool required { get; set; }
        public string location { get; set; }
    }

}