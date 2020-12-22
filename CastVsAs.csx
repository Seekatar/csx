using static System.Console;

class a
{
    public int MyProperty { get; set; } = 12;
}

class b : a
{
}

object aa = new a();
object s;
try
{
    var s = (string)aa;
} catch (Exception)
{
    WriteLine( "Cast to string threw" );
}
try
{
    var s = (b)aa;
} catch (Exception)
{
    WriteLine( "Cast to b threw" );
}

s = aa as a;
WriteLine( $"s as a is {s}" );
s = aa as b;
WriteLine( $"s as b is {s}" );
s = aa as string;
WriteLine( $"s as string is {s}" );

