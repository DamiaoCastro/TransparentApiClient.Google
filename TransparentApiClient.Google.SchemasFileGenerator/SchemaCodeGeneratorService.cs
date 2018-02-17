using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransparentApiClient.Google.SchemasFileGenerator {
    internal class SchemaCodeGeneratorService {

        private string newLine = Environment.NewLine;

        internal IEnumerable<(string id, string fileContent)> GetFileContents(GoogleApiDiscover googleApiDiscover) {

            foreach (JProperty schemaProperty in googleApiDiscover.schemas.Children()) {

                Console.WriteLine($"schema property '{schemaProperty.Name}'");

                yield return GetClassCodeString(schemaProperty);

            }

        }

        (string id, string content) GetClassCodeString(JProperty schemaProperty) {
            var children = schemaProperty.Children();
            string id = schemaProperty.Children().Values("id").First().ToObject<JValue>().Value.ToString();

            var classContent = GetClassCodeString(id, children);
            if (!string.IsNullOrWhiteSpace(classContent)) {
                return (id, $"using System.Collections.Generic;{newLine}using Newtonsoft.Json;{newLine}{newLine}namespace TransparentApiClient.Google.BigQuery.V2.Schema {{ {newLine}{classContent}{newLine}}}");
            }

            return (id, null);
        }

        string GetClassCodeString(string id, IJEnumerable<JToken> children) {
            IEnumerable<JToken> properties = children.Values("properties");
            if (properties.Count() > 0) {
                var property = properties.First().Select(c => GetPropertyCodeString(c)).ToArray();

                var adicionalClasses = new List<string>();
                var fileContent = new StringBuilder($"\tpublic class {id} {{ {newLine}{newLine}");
                foreach (var item in property) {
                    fileContent.AppendLine($"{item.propertyString}{newLine}");

                    if (!string.IsNullOrWhiteSpace(item.adicionalClass)) {
                        adicionalClasses.Add(item.adicionalClass);
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

        (string propertyString, string adicionalClass) GetPropertyCodeString(JToken token) {

            string name = ((JProperty)token).Name;
            string adicionalClass = null;

            string typeName = "object", originalTypeName = "object";
            var type = token.Values("type");
            if (type.Count() > 0) {
                originalTypeName = type.First().ToObject<JValue>().Value.ToString().ToLower();
                typeName = originalTypeName;

                switch (typeName) {
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
                        typeName = token.Values("format").First().ToObject<JValue>().Value.ToString();
                        break;
                    case "array":
                        var enumerableType = "object";
                        IJEnumerable<JToken> items = token.Values("items");
                        if (items.Count() > 0) {
                            var subItemProperties = items.First().Children().OfType<JProperty>();
                            var subItemPropertyType = subItemProperties.Where(c => c.Name == "type");
                            if (subItemPropertyType.Any()) {

                                var subItemPropertyObject = subItemProperties.FirstOrDefault(c => c.Name == "properties");
                                if (subItemPropertyObject != null && subItemPropertyObject.Values().Count() > 0) {

                                    enumerableType = $"{name.Substring(0, 1).ToUpper()}{ name.Substring(1)}";
                                    if (!enumerableType.EndsWith("ss")) {
                                        enumerableType = enumerableType.TrimEnd('s');
                                    }
                                    adicionalClass = GetClassCodeString(enumerableType, items);

                                }

                            } else {
                                var @ref = enumerableType = subItemProperties.FirstOrDefault(c => c.Name == "$ref")?.Value.ToString();
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
            var description = token.Values("description");
            if (description.Count() > 0) {
                descriptionString = $"/// <summary>{newLine}\t\t/// {description.First().ToObject<JValue>().Value.ToString()}{newLine}\t\t/// </summary>";
            }

            //optional
            var optional = (!string.IsNullOrWhiteSpace(descriptionString)) && descriptionString.Contains("[Optional]");
            var optionalPossible = optional && (!new string[] { "string", "array", "object" }.Contains(originalTypeName));

            var property = $"public {typeName}{(optionalPossible ? "?" : string.Empty)} {name} {{ get; set; }}";

            //default
            var @default = token.Values("default");
            if (@default.Count() > 0) {
                var defaultString = @default.First().ToObject<JValue>().Value.ToString();
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