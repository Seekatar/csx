// Requires NuGet: Seekatar.Tools 0.2.4
// Requires NuGet: Seekatar.OptionToStringGenerator 0.3.5
using Seekatar;

var x = Seekatar.Mask.MaskRegex("testSecret=123", ".*Secret=(.*)");
Console.WriteLine(x);

x = Seekatar.Mask.MaskRegex("testSecret=123", ".*Secret=(.*)", mask:(s) => s.Replace(s, $"****{s}***"));
Console.WriteLine(x);

x = Seekatar.Mask.MaskRegex("testSect=123", ".*Secret=(.*)", mask:(s) => s.Replace(s, $"****{s}***"));
Console.WriteLine(x);