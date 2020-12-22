using static System.Console;

var count = 1000;

var d = new Dictionary<string,string>(1);

for ( int i = 1; i < count; i++ )
{
    d.Add( $"Phase{i}", "test" );
}

d.Add("Apple", "test" );
d.Add("Orange", "test" );
d.Add("Apricot", "test" );
d.Add("Banana", "test" );
d.Add("Mango", "test" );

foreach ( var kv in d )
{
    WriteLine( $"KeyValue is {kv.Key}" );
}

foreach ( var ky in d.Keys )
{
    WriteLine( $"Key is {ky}" );

}