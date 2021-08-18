//-----------------------------------------------------------------------
// <copyright file="CSharpGeneratorSettings.cs" company="NJsonSchema">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/RicoSuter/NJsonSchema/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System.Reflection;

namespace NJsonSchema.CodeGeneration.CSharp
{
    /// <summary>The generator settings.</summary>
    public class CSharpGeneratorSettings : CodeGeneratorSettingsBase
    {
        /// <summary>Initializes a new instance of the <see cref="CSharpGeneratorSettings"/> class.</summary>
        public CSharpGeneratorSettings()
        {
            AnyType = "object";
            Namespace = "MyNamespace";

            DateType = "System.DateTimeOffset";
            DateTimeType = "System.DateTimeOffset";
            TimeType = "System.TimeSpan";
            TimeSpanType = "System.TimeSpan";

            ArrayType = "System.Collections.Generic.ICollection";
            ArrayInstanceType = "System.Collections.ObjectModel.Collection";
            ArrayBaseType = "System.Collections.ObjectModel.Collection";

            DictionaryType = "System.Collections.Generic.IDictionary";
            DictionaryInstanceType = "System.Collections.Generic.Dictionary";
            DictionaryBaseType = "System.Collections.Generic.Dictionary";

            ClassStyle = CSharpClassStyle.Poco;
            JsonLibrary = CSharpJsonLibrary.NewtonsoftJson;

            RequiredPropertiesMustBeDefined = true;
            GenerateDataAnnotations = true;
            TypeAccessModifier = "public";
            PropertySetterAccessModifier = string.Empty;
            GenerateJsonMethods = false;
            EnforceFlagEnums = false;

            PropertyNamingStyle = CSharpNamingStyle.PascalSnakeCase;
            ClassNamingStyle = CSharpNamingStyle.PascalCase;

            ValueGenerator = new CSharpValueGenerator(this);
            PropertyNameGenerator = new CSharpPropertyNameGenerator(this);
            TemplateFactory = new DefaultTemplateFactory(this, new Assembly[]
            {
                typeof(CSharpGeneratorSettings).GetTypeInfo().Assembly
            });

            InlineNamedArrays = false;
            InlineNamedDictionaries = false;
            InlineNamedTuples = true;
        }

        /// <summary>Gets or sets the .NET namespace of the generated types (default: MyNamespace).</summary>
        public string Namespace { get; set; }

        /// <summary>Gets or sets a value indicating whether a required property must be defined in JSON
        /// (sets Required.Always when the property is required) (default: true).</summary>
        public bool RequiredPropertiesMustBeDefined { get; set; }

        /// <summary>Gets or sets a value indicating whether to generated data annotation attributes (default: true).</summary>
        public bool GenerateDataAnnotations { get; set; }

        /// <summary>Gets or sets the any type (default: "object").</summary>
        public string AnyType { get; set; }

        /// <summary>Gets or sets the date .NET type (default: 'DateTimeOffset').</summary>
        public string DateType { get; set; }

        /// <summary>Gets or sets the date time .NET type (default: 'DateTimeOffset').</summary>
        public string DateTimeType { get; set; }

        /// <summary>Gets or sets the time .NET type (default: 'TimeSpan').</summary>
        public string TimeType { get; set; }

        /// <summary>Gets or sets the time span .NET type (default: 'TimeSpan').</summary>
        public string TimeSpanType { get; set; }

        /// <summary>Gets or sets the generic array .NET type (default: 'ICollection').</summary>
        public string ArrayType { get; set; }

        /// <summary>Gets or sets the generic dictionary .NET type (default: 'IDictionary').</summary>
        public string DictionaryType { get; set; }

        /// <summary>Gets or sets the generic array .NET type which is used for ArrayType instances (default: 'Collection').</summary>
        public string ArrayInstanceType { get; set; }

        /// <summary>Gets or sets the generic dictionary .NET type which is used for DictionaryType instances (default: 'Dictionary').</summary>
        public string DictionaryInstanceType { get; set; }

        /// <summary>Gets or sets the generic array .NET type which is used as base class (default: 'Collection').</summary>
        public string ArrayBaseType { get; set; }

        /// <summary>Gets or sets the generic dictionary .NET type which is used as base class (default: 'Dictionary').</summary>
        public string DictionaryBaseType { get; set; }

        /// <summary>Gets or sets the CSharp class style (default: 'Poco').</summary>
        public CSharpClassStyle ClassStyle { get; set; }

        /// <summary>Gets or sets the CSharp JSON library to use (default: 'NewtonsoftJson', 'SystemTextJson' is experimental/not complete).</summary>
        public CSharpJsonLibrary JsonLibrary { get; set; }

        /// <summary>Gets or sets the access modifier of generated classes and interfaces (default: 'public').</summary>
        public string TypeAccessModifier { get; set; }

        /// <summary>Gets the access modifier of property setters (default: '').</summary>
        public string PropertySetterAccessModifier { get; set; }

        /// <summary>Gets or sets the custom Json.NET converters (class names) which are registered for serialization and deserialization.</summary>
        public string[] JsonConverters { get; set; }

        /// <summary>Gets or sets a value indicating whether to remove the setter for non-nullable array properties (default: false).</summary>
        public bool GenerateImmutableArrayProperties { get; set; }

        /// <summary>Gets or sets a value indicating whether to remove the setter for non-nullable dictionary properties (default: false).</summary>
        public bool GenerateImmutableDictionaryProperties { get; set; }

        /// <summary>Gets or sets a value indicating whether to use preserve references handling (All) in the JSON serializer (default: false).</summary>
        public bool HandleReferences { get; set; }

        /// <summary>Gets or sets the name of a static method which is called to transform the JsonSerializerSettings (for Newtonsoft.Json) or the JsonSerializerOptions (for System.Text.Json) used in the generated ToJson()/FromJson() methods (default: null).</summary>
        public string JsonSerializerSettingsTransformationMethod { get; set; }

        /// <summary>Gets or sets a value indicating whether to render ToJson() and FromJson() methods (default: false).</summary>
        public bool GenerateJsonMethods { get; set; }

        /// <summary>Gets or sets a value indicating whether enums should be always generated as bit flags (default: false).</summary>
        public bool EnforceFlagEnums { get; set; }

        /// <summary>Gets or sets a value indicating whether named/referenced dictionaries should be inlined or generated as class with dictionary inheritance.</summary>
        public bool InlineNamedDictionaries { get; set; }

        /// <summary>Gets or sets a value indicating whether named/referenced tuples should be inlined or generated as class with tuple inheritance.</summary>
        public bool InlineNamedTuples { get; set; }

        /// <summary>Gets or sets a value indicating whether named/referenced arrays should be inlined or generated as class with array inheritance.</summary>
        public bool InlineNamedArrays { get; set; }

        /// <summary>Gets or sets a value indicating whether optional schema properties (not required) are generated as nullable properties (default: false).</summary>
        public bool GenerateOptionalPropertiesAsNullable { get; set; }

        /// <summary>Gets or sets a value indicating whether to generate Nullable Reference Type annotations (default: false).</summary>
        public bool GenerateNullableReferenceTypes { get; set; }

        /// <summary>Gets or sets a value indicating what type of naming style to use for properties (default: PascalSnakeCase).</summary>
        public CSharpNamingStyle PropertyNamingStyle { get; set; }

        /// <summary>Gets or sets a value indicating what type of naming style to use for classes (default: PascalCase).</summary>
        public CSharpNamingStyle ClassNamingStyle { get; set; }
    }
}
