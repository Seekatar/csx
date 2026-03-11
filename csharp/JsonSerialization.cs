using Newtonsoft;
using static System.Console;

B b = new();
A a = b;

WriteLine($"b = {Newtonsoft.Json.JsonConvert.SerializeObject(b)}");
WriteLine($"(A)b = {Newtonsoft.Json.JsonConvert.SerializeObject((A)b)}");
WriteLine($"a = {Newtonsoft.Json.JsonConvert.SerializeObject(a)}");

class A {
    public string a => "this is a";
}

class B : A {
    public string b => "this is b";
}