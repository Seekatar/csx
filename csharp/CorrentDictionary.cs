using System.Collections.Concurrent;
var c = new ConcurrentDictionary<string, int>();
c["a"] = 1;
c["b"] = 2;

var x = c["d"];