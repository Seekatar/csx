class test
{
    static List<int> numbers = new List < int >() { 1, 2 }; 
    
    static public IEnumerable<int> doit()
    {
        numbers.Add(1);
        numbers.Add(2);

        IEnumerable < int > query = numbers.Select (n => n * 10); 
        
        numbers.Clear(); 
        
        return query;
    }
    
    static public IEnumerable<int> doit2()
    {
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        
        IEnumerable < int > query = numbers.Select (n => n * 10).ToList(); 
        
        numbers.Clear(); 
        
        return query;
    }
}

Console.WriteLine("doit");
foreach( var i in test.doit() )
    Console.WriteLine(i);
    
Console.WriteLine("doit2");
foreach( var i in test.doit2() )
    Console.WriteLine(i);

Console.WriteLine("doit2");
foreach( var i in test.doit2() )
    Console.WriteLine(i);
