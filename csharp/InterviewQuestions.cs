using static System.Console;

// Linq
// What is expected output of the numbers?

var sqlTable = new List<string>() {"a", "b", "c", "a"};

WriteLine("1");
var groups = sqlTable.GroupBy(x => { WriteLine("2"); return x; });
WriteLine("3");
var select = groups.Select(x => { WriteLine( "4"); return new { Key = x.Key, Count = x.Count() }; });
WriteLine("5");
var result = select.OrderByDescending(x => { WriteLine( "6"); return x.Count; } );
WriteLine("7");

foreach (var item in result)
{
    DoSomething(item);
}

void DoSomething(object item){}

// Bug 1
// remove 'a' from the list
// one bug, how to resolve it

var list = new List<string>() {"a", "b", "c","a", "b", "c", "a", "b", "d"};

foreach (var l in list)
{
    if ( l == "a")
    {
        list.Remove(l);
    }
}
WriteLine(list);

// Bug 2
// find "and" in the list
// two bugs

string findMe = "and";
string s;
var list2 = new string[] { "fish", "and", "chips" };

for (int i = 0; i <= list2.Length; i++)
{
    if ( s == list2[i] )
        WriteLine(list2[i]);
}

// Bug 3
// multi-threaded count up to 200, but sometimes goes higher
// threading bug in class A
// .NET-specific bug in the code to run the threads

// main bug in this class

var a = new A();

// .NET-specific bug in this code

// run 3 threads to call A.IncrementNumber
var task = new List<Task>();
for (var j = 0; j < 3; j++)
{
    task.Add(Task.Run(() => {
        while( a.IncrementNumber() )
        {
            // wait for true
        }
    }));
}
WriteLine($"Done! {a.x}");

// 4 Singleton
// how to make this reliably work

// 5 Write strtoi
// write function to convert string of numbers to an integer
// may only use primitive statements
// may not call any built-in methods or functions

string str = "123";

int convert(string s)
{
    int i = 0;
    // without calling any functions, convert s to 123

#region hint to convert char to number
    char c = '4';
    int j = c - '0';
#endregion

    return i;
}

WriteLine(convert(str)); // print 123

public class A
{
    public int x = 0;

    public bool IncrementNumber()
    {
        if (x < 200)
        {
            // do some work
            x += 1;
            return true;
        }
        return false;
    }
}

class MySingleton
{
    // one bug
    static MySingleton a;
    private MySingleton() {}

    public static MySingleton Instance()
    {
        if (a == null)
            a = new MySingleton();
        return a;
    }
}
