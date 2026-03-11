using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Console;

var obj = new test { Name = "test" };
var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true,
 PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

WriteLine(obj.Name);
WriteLine(json);

// don't neeed to use JsonPropertyName, if use the PropertyNamingPolicy = JsonNamingPolicy.CamelCase
// which you can set in the ASP.NET with  .AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//     options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
// });
[DataContract]
class test {
    [DataMember(Name = "name")]
    // [JsonPropertyName("name")]
    public string Name { get; set; }
}