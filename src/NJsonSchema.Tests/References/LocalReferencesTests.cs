﻿using System.Threading.Tasks;
using Xunit;

namespace NJsonSchema.Tests.References
{
    public class LocalReferencesTests
    {
        [Fact]
        public async Task When_definitions_is_nested_then_refs_work()
        {
            //// Arrange
            var json = @"{
	""type"": ""object"", 
	""properties"": {
		""foo"": {
			""$ref"": ""#/definitions/collection/bar""
		}
	},
	""definitions"": {
		""collection"": {
			""bar"": {
				""type"": ""integer""
			}
		}
	}
}";
            
            //// Act
            var schema = await JsonSchema4.FromJsonAsync(json);
            var j = schema.ToJson();

            //// Assert
            Assert.Equal(JsonObjectType.Integer, schema.Properties["foo"].ActualTypeSchema.Type);
        }

        [Fact]
        public async Task When_schema_references_collection_in_definitions_it_works()
        {
            //// Arrange
            var path = "References/LocalReferencesTests/schema_with_collection_reference.json";

            //// Act
            var schema = await JsonSchema4.FromFileAsync(path);
            var json = schema.ToJson();

            //// Assert
            Assert.Equal(JsonObjectType.Integer, schema.Properties["foo"].ActualTypeSchema.Type);
            Assert.Equal(1, schema.Definitions.Count);
            Assert.Equal("./collection.json", schema.Definitions["collection"].DocumentPath);
        }

        [Fact]
        public async Task When_schema_references_external_schema_then_it_is_inlined_with_ToJson()
        {
            //// Arrange
            var path = "References/LocalReferencesTests/schema_with_reference.json";

            //// Act
            var schema = await JsonSchema4.FromFileAsync(path);
            var json = schema.ToJson();

            //// Assert
            Assert.True(schema.Definitions.ContainsKey("Animal"));
            Assert.True(json.Contains("\"$ref\": \"#/definitions/Animal\""));
        }

        //[TestMethod]
        //public async Task When_schema_references_external_schema_then_it_is_removed_with_ToJsonWithExternalReferences()
        //{
        //    //// Arrange
        //    var path = "References/LocalReferencesTests/schema_with_reference.json";

        //    //// Act
        //    var schema = await JsonSchema4.FromFileAsync(path);
        //    var json = schema.ToJsonWithExternalReferences();

        //    //// Assert
        //    Assert.AreEqual(0, schema.Definitions.Count);
        //}

        [Fact]
        public async Task When_document_has_indirect_external_ref_than_it_is_loaded()
        {
            //// Arrange
            var path = "References/LocalReferencesTests/schema_with_indirect_reference.json";

            //// Act
            var schema = await JsonSchema4.FromFileAsync(path);
            var json = schema.ToJson();

            //// Assert
            Assert.Equal(1, schema.Definitions.Count);
        }
    }
}
