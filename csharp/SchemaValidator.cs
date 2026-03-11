// Requires NuGet: NJsonSchema
// Requires NuGet: Newtonsoft.Json 12.0.3
// Requires NuGet: Newtonsoft.Json.Schema 3.0.13
using NJsonSchema;
using System.IO;
using static System.Console;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;

var inputFile = "/Users/jwallace/code/ConditionalForms/src/test/test-input/value-validation-test.json";
var schemaFile = "/Users/jwallace/code/ConditionalForms/src/test/test-input/cf-schema.json";
schemaFile = "/Users/jwallace/code/ConditionalForms/src/test/test-input/cf-schema2.json";

var schema = await JsonSchema.FromJsonAsync(File.ReadAllText(schemaFile));
WriteLine("GOto schema");

var errors = schema.Validate(File.ReadAllText(inputFile));

foreach (var error in errors)
    Console.WriteLine($"{error.Path}: {error.Kind} '{error.Property}' {error.LineNumber} {error.LinePosition}");
    //WriteLine(JsonSerializer.Serialize(error, new JsonSerializerOptions() { }));

{
    var inputFile2 = "/Users/jwallace/code/ConditionalForms/src/test/test-input/value-validation-test.json";
    var schemaFile2 = "/Users/jwallace/code/ConditionalForms/src/test/test-input/cf-schema.json";
    //schemaFile2 = "/Users/jwallace/code/ConditionalForms/src/test/test-input/cf-schema2.json";

    string schemaJson = schemaFile2;
    string file = inputFile2;

    if (!File.Exists(schemaJson) || !File.Exists(file)) {
        WriteLine("Must enter existing file for --schema-json and --file to validate. Got:");
        WriteLine($"     {schemaJson}");
        WriteLine($"     {file}");
        return;
    }
    JSchema schema2 = JSchema.Parse(File.ReadAllText(schemaJson));
    JToken json = JToken.Parse(File.ReadAllText(file));

    bool valid = json.IsValid(schema2, out IList<string> messages);
    if (!valid)
    {
        WriteLine("Invalid!");
        foreach( var i in messages)
        {
            WriteLine($"   {i}");
        }
    }
    else
    {
        WriteLine("valid");
    }
}