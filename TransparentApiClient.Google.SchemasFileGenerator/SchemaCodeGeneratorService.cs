using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransparentApiClient.Google.SchemasFileGenerator {
    internal class SchemaCodeGeneratorService {

        public SchemaCodeGeneratorService(string @namespace) {
            this.@namespace = @namespace;
        }

        private string newLine = Environment.NewLine;
        private readonly string @namespace;

        internal IEnumerable<(string id, string fileContent)> GetFileContents(GoogleApiDiscover googleApiDiscover) {

            foreach (KeyValuePair<string, GoogleApiDiscoverSchema> schemaProperty in googleApiDiscover.schemas) {

                Console.WriteLine($"schema property '{schemaProperty.Key}'");

                yield return GetClassCodeString(schemaProperty);

            }

        }

        (string id, string content) GetClassCodeString(KeyValuePair<string, GoogleApiDiscoverSchema> schemaProperty) {
            string id = schemaProperty.Key;
            var children = schemaProperty.Value;

            var classContent = GetClassCodeString(id, children);
            if (!string.IsNullOrWhiteSpace(classContent)) {
                return (id, $"using System.Collections.Generic;{newLine}using Newtonsoft.Json;{newLine}{newLine}namespace {@namespace}.Schema {{ {newLine}{classContent}{newLine}}}");
            }

            return (id, null);
        }

        string GetClassCodeString(string id, GoogleApiDiscoverSchema schema) {

            if (schema.properties != null /*&& schema.properties.Count() > 0*/) {

                var adicionalClasses = new List<string>();
                var fileContent = new StringBuilder($"\tpublic class {id} {{ {newLine}{newLine}");
                foreach (var item in schema.properties) {

                    var property = GetPropertyCodeString(item);

                    fileContent.AppendLine($"{property.propertyString}{newLine}");

                    if (!string.IsNullOrWhiteSpace(property.adicionalClass)) {
                        adicionalClasses.Add(property.adicionalClass);
                    }
                }

                foreach (var adicionalClass in adicionalClasses) {
                    fileContent.AppendLine(adicionalClass);
                }

                fileContent.Append($"\t}}");

                return fileContent.ToString();
            }

            return null;
        }

        (string propertyString, string adicionalClass) GetPropertyCodeString(KeyValuePair<string, GoogleApiDiscoverSchema> token) {

            string name = token.Key;
            string adicionalClass = null;
            bool isCustomType = false;

            string typeName = "object", originalTypeName = "object";
            var type = token.Value.type;
            if (string.IsNullOrWhiteSpace(type)) {
                if (!string.IsNullOrWhiteSpace(token.Value.refName)) {
                    if (token.Value.refName.ToLower() != "jsonobject") {
                        typeName = token.Value.refName;
                        originalTypeName = typeName;
                        isCustomType = true;
                    }
                }
            } else {
                originalTypeName = token.Value.type.ToLower();
                typeName = originalTypeName;

                switch (typeName) {
                    case "object":
                        if (!string.IsNullOrWhiteSpace(token.Value.additionalProperties?.refName)) {
                            typeName = token.Value.additionalProperties.refName;
                        }
                        break;
                    case "any":
                        typeName = "object";
                        break;
                    case "boolean":
                        typeName = "bool";
                        break;
                    case "integer":
                        typeName = "int";
                        break;
                    case "number":
                        typeName = token.Value.format;
                        break;
                    case "array":
                        var enumerableType = "object";
                        if (token.Value.items != null) {
                            var subItemPropertyType = token.Value.items.type;
                            if (!string.IsNullOrWhiteSpace(subItemPropertyType)) {

                                var subItemPropertyObject = token.Value.items.properties;
                                if (subItemPropertyObject != null) {

                                    enumerableType = $"{name.Substring(0, 1).ToUpper()}{ name.Substring(1)}";
                                    if (!enumerableType.EndsWith("ss")) {
                                        enumerableType = enumerableType.TrimEnd('s');
                                    }
                                    adicionalClass = GetClassCodeString(enumerableType,
                                        new GoogleApiDiscoverSchema() {
                                            properties = token.Value.items.properties
                                        });

                                }

                            } else {
                                var @ref = enumerableType = token.Value.items.refName;
                                if (!string.IsNullOrWhiteSpace(@ref)) {
                                    enumerableType = @ref;
                                }
                            }
                        }
                        typeName = $"IEnumerable<{enumerableType}>";
                        break;
                }
            }

            //description
            var descriptionString = string.Empty;
            if (!string.IsNullOrWhiteSpace(token.Value.description)) {
                var descriptionLines = token.Value.description.Split("\n");

                descriptionString = $"/// <summary>{newLine}\t\t/// {string.Join($"{newLine}\t\t///", descriptionLines)}{newLine}\t\t/// </summary>";
            }

            //optional
            var optional = (!string.IsNullOrWhiteSpace(descriptionString)) && descriptionString.Contains("[Optional]");
            var optionalPossible = optional && (!isCustomType) && (!new string[] { "string", "array", "object" }.Contains(originalTypeName));

            var property = $"public {typeName}{(optionalPossible ? "?" : string.Empty)} {name} {{ get; set; }}";

            //default
            string @default = token.Value.@default;
            if (!string.IsNullOrWhiteSpace(@default)) {
                var defaultString = @default;
                if (typeName.ToLower() == "string") {
                    property = $"{property} = \"{defaultString.Replace("\"", "\\\"")}\";";
                } else {
                    property = $"{property} = {defaultString};";
                }
            }

            var propertyBuilder = new String[] { descriptionString, (optional ? "[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]" : string.Empty), property };

            var propertyString = string.Join(newLine, propertyBuilder.Where(c => !string.IsNullOrWhiteSpace(c)).Select(c => $"\t\t{c}"));

            return (propertyString, adicionalClass);
        }

    }
}