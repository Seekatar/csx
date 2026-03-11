using static System.Console;
using System.Globalization;

// ASCII ) = 41, , = 44
WriteLine($"{')' < ','}"); // True
WriteLine(String.Compare(")", ",")); // 1?!
WriteLine(String.CompareOrdinal(")", ",")); // -3

string str1 = ")";
string str2 = ",";
CultureInfo culture = CultureInfo.CurrentCulture; // Your locale here
WriteLine(String.Compare(str1, str2, culture, CompareOptions.None)); // 1?!

WriteLine((int)')'); // 41
WriteLine((int)','); // 44

var s = new List<string>();
for ( var i = ' '; i <= '~'; i++ )
{
    s.Add(i.ToString());
}
var sorted = s.OrderBy(x => x).ToList();
WriteLine("Default OrderBy");
WriteLine(string.Join("",sorted));

sorted = s.OrderBy(x => x, new OrdinalStringComparer()).ToList();
WriteLine("Ordinal OrderBy (ASCII/UTF8)");
WriteLine(string.Join("",sorted));

class OrdinalStringComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        return String.CompareOrdinal(x, y);
    }
}