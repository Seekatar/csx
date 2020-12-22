#r "$NuGet\Newtonsoft.Json\10.0.3\lib\net45\Newtonsoft.Json.dll"

using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Console;

var _ctmUrl = "http://continuum/api/get_pipelineinstance?pi=5984a091b9b3ab6a26e364f&?token={0}";
var _ctmKey = "581cc5b87c1a7c5a12eae6b9";



var result = new WebClient().DownloadString(new Uri("http://172.16.60.44:8080/api/get_pipelineinstance?pi=5989ddad683f244401556b12&token=5988590a683f2444015568fc&include_stages=True"));
dynamic root = JsonConvert.DeserializeObject(result);

WriteLine( result );
var total = 0;
var totalSuccess = 0;
var totalFailed = 0;
var runningIndex = 0;
var totalSkipped = 0;
var currentPhase = string.Empty;
var currentStage = string.Empty;
var currentStep = string.Empty;
var piStatus = root.Response.status;
var pendingStepNo = -1;
var pendingTitle = string.Empty;
var pendingQ = string.Empty;
var pendingKey = string.Empty;

foreach ( var p in root.Response.phases )
{
    WriteLine(p.name);
    foreach ( var s in p.stages )
    {
        dynamic ss = JsonConvert.DeserializeObject(s.ToString().Substring(s.ToString().IndexOf("{")));
        WriteLine( "    "+ss.name );
        var stepNo = -1;
        foreach ( var step in ss.steps )
        {
            stepNo++;
            if ( step.when == "never" )
                continue;
                
            var msg = step.name.ToString();
            if ( string.IsNullOrWhiteSpace(msg) )
                msg = step.plugin.label;
            var status = step.status?.ToString();
            if ( string.IsNullOrWhiteSpace(status) )
                status = "not run";
                
            WriteLine( $"        {status} -> {msg}");
            total++;
            
            if ( step.status != null )
            {
                switch ( step.status.ToString() )
                {
                    case "success":
                        totalSuccess++;
                        break;
                    case "skipped":
                        totalSkipped++;
                        break;
                    case "processing":
                    case "failure":
                    case "canceled":
                        totalFailed++;
                        runningIndex = total;
                        currentPhase = p.name;
                        currentStage = ss.name;
                        currentStep = msg;
                        break;
                    case "pending":
                        piStatus = "pending";
                        runningIndex = total;
                        currentPhase = p.name;
                        currentStage = ss.name;
                        currentStep = msg;
                        pendingStepNo = stepNo;
                        pendingKey = step.plugin.args.result_key;
                        pendingQ = step.plugin.args.text;
                        pendingTitle = step.plugin.args.title;
                        break;
                    default:
                        break; // not run yet
                }
            }
        }
        
    }
    
}

WriteLine( $"Total {total} Success {totalSuccess} Failed {totalFailed} Index {runningIndex} Skipped {totalSkipped} Complete {100*runningIndex/total}%" );
WriteLine($"Pending step is {pendingStepNo} {pendingTitle} {pendingQ} {pendingKey}");
WriteLine( $"Status is {piStatus} at '{currentPhase}'->'{currentStage}'->'{currentStep}'" );

