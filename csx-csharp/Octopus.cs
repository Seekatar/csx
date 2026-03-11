// Requires DLL: Newtonsoft.Json.dll
// Requires DLL: Octopus.Client.dll

using Octopus.Client;

var server = "http://octopus/";
var apiKey = "BOGUS";
var octopusEndpoint = new OctopusServerEndpoint(server, apiKey);
System.Console.WriteLine("1");
var octopusRepository = new OctopusRepository(octopusEndpoint);

var octopusMachine = octopusRepository.Machines.FindByName("LCHOST-14");
System.Console.WriteLine(octopusMachine);
