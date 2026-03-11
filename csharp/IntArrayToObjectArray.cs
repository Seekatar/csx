var x = new Int64 [] { 1, 2, 3, 5, };
object y = x;

var o = ((Array)y) as object[];
if (o != null)
    Console.WriteLine(o.Length); // 4
else
    Console.WriteLine("not an array");

if (y != null)
    Console.WriteLine("not null"); // 4
else
    Console.WriteLine("null");

// Cell 2

var x2 = new Int64[] { 1, 2, 3, 5 };
object y2 = x2;

var elementType = y2.GetType().GetElementType();
if (elementType.IsValueType || elementType == typeof(object))
{
    var yArray = (Array)y2;
    var o2 = new object[yArray.Length];
    Array.Copy(yArray, o2, yArray.Length);
    if (o2 != null)
        Console.WriteLine(o2.Length); // 4
    else
        Console.WriteLine("not an array");
}
else
{
    Console.WriteLine("not an array");
}

if (y2 != null)
    Console.WriteLine("not null"); // not null
else
    Console.WriteLine("null");