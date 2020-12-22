#r "$NuGet\Newtonsoft.Json\10.0.2\lib\net45\Newtonsoft.Json.dll"
using Newtonsoft.Json;

var _zabbixUser = "Admin";
var _zabbixPw = "secret";
var _sessionId = "233";

var body = String.Format(@"{{
					""jsonrpc"": ""2.0"",
					""method"": ""user.login"",
					""params"": {{
						""user"": ""{0}"",
						""password"": ""{1}""
					}},
					""id"": 1,
					""auth"": null
				}}", _zabbixUser, _zabbixPw);

dynamic o = JsonConvert.DeserializeObject( body );
Console.WriteLine( o.jsonrpc );

			body = String.Format(@"{{
			""jsonrpc"": ""2.0"",
			""method"": ""event.get"",
			""params"": {{
					""output"": [""objectid"",""r_eventid""],
					""sortfield"":""clock"",
					""sortorder"":""DESC"",
					""value"":1,
					""limit"":12
			}},
			""id"": 3,
			""auth"": ""{0}""
			}}", _sessionId);
			
o = JsonConvert.DeserializeObject( body );
Console.WriteLine( o["params"].output[0]);
Console.WriteLine( o.auth);