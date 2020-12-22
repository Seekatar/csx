class test
{
    public test(int y ) { x = y; }
    public int x;
}

class b
{
    public b() {
     y.Add( new test(2) );
     y.Add(new test(43) ); 
    } 
     
    public List<test> y = new List<test>();
}

b bb = null; // new b();;
foreach ( var yy in bb?.y )
    Console.WriteLine(yy.x);