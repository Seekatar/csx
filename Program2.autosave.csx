using System;
using System.Linq;
 

		var beatles = (new[]
            {
                new {id = 5, major = 17, minor = 2, productID = 1, name = "ringo1", MajorMinor = "17.2"},
                new {id = 2, major = 17, minor = 1, productID = 1, name = "john2", MajorMinor = "17.1"},
                new {id = 8, major = 17, minor = 2, productID = 1, name = "ringo4", MajorMinor = "17.2"},
                new {id = 3, major = 17, minor = 1, productID = 1, name = "john3", MajorMinor = "17.1"},
                new {id = 4, major = 17, minor = 1, productID = 1, name = "john4", MajorMinor = "17.1"},
                new {id = 1, major = 17, minor = 1, productID = 1, name = "john1", MajorMinor = "17.1"},
                new {id = 6, major = 17, minor = 2, productID = 1, name = "ringo2", MajorMinor = "17.2"},
                new {id = 7, major = 17, minor = 2, productID = 1, name = "ringo3", MajorMinor = "17.2"},
            });
 
            var result = beatles
                .GroupBy(g => new { g.MajorMinor, g.productID } )
                .Select(c => c.OrderBy(o => o.id).Select((v, i) => new { i, v }).ToList())
                
                .SelectMany(c => c.Take(2))
                .Select(c => c.v)
                .ToList();
 
            Console.WriteLine("id | inst \t| name  \t| rn");
            foreach (var row in result)
            {
                Console.WriteLine($"{row.id}  | {row.MajorMinor}\t| {row.name}  \t|");
            }     
