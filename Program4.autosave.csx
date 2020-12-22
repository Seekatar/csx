using static System.Console;

enum E
{
    a,
    b,
    c,
    asdfasdfasdf
};

;
WriteLine( $" {Enum.TryParse<E>( "ASDFASDFASDF", out var eee)} eee is {eee}" );

WriteLine(Enum.GetValues(typeof(E)).GetValue(0) );
E e = (E)7;
E e2 = E.a;

Console.WriteLine( e );
Console.WriteLine( e2 );