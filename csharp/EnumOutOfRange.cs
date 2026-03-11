using static System.Console;
using System.Text.Json;
using System.Text.Json.Serialization;

// deserialize JSON to object
var obj = JsonSerializer.Deserialize<Test>(@"{""Name"":""test"", ""Color"":""Green""}");
WriteLine($"{obj.Name} {obj.Color} {Enum.IsDefined<Test.EColor>(obj.Color)}");

obj = JsonSerializer.Deserialize<Test>(@"{""Name"":""test"", ""Color"":""2""}");
WriteLine($"{obj.Name} {obj.Color} {Enum.IsDefined<Test.EColor>(obj.Color)}");


obj = JsonSerializer.Deserialize<Test>(@"{""Name"":""test"", ""Color"":""200""}");
WriteLine($"{obj.Name} {obj.Color} {Enum.IsDefined<Test.EColor>(obj.Color)}");

class Test {
    public enum EColor { Red, Green, Blue };

    public string Name { get; set; } = "";

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EColor Color { get; set; } = EColor.Red;
}