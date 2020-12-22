#r "C:\Development\site-vacuum\packages\Newtonsoft.Json.9.0.1\lib\net45\Newtonsoft.Json.dll"
#r "C:\Development\site-vacuum\packages\Octopus.Client.4.0.1\lib\net45\Octopus.Client.dll"

using Octopus.Client;

var server = "http://octopus/";
var apiKey = "API-02OKJAWL070QWDOGORG4NNSYI";
var octopusEndpoint = new OctopusServerEndpoint(server, apiKey);
System.Console.WriteLine("1");
var octopusRepository = new OctopusRepository(octopusEndpoint);

var octopusMachine = octopusRepository.Machines.FindByName("LCHOST-14");
System.Console.WriteLine(octopusMachine);
