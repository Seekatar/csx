#r "C:\Development\site-vacuum\packages\IIS.Microsoft.Web.Administration.8.5.9600.17042\lib\Microsoft.Web.Administration.dll"

using Microsoft.Web.Administration;

using (var serverManager = ServerManager.OpenRemote("localhost"))
{
	foreach (var site in serverManager.Sites)
	{
		 Console.WriteLine( $"Site name is {site.Name}" );
		foreach (var app in site.Applications)
		{
			if (app.Path.Equals("/"))
			{
				continue;
			}
    		Console.WriteLine( $"   App.AppPoolName is {app.ApplicationPoolName} and path is {app.Path}" );
			foreach (var virtualDirectory in app.VirtualDirectories)
			{
			     Console.WriteLine( "        VDirPath {virtualDirectory.PhysicalPath}" );
			}
			
			// if ( app.ApplicationPoolName.StartsWith("V1-Core-" ) )
			{
    			var appPool = serverManager.ApplicationPools.FirstOrDefault(o => o.Name == app.ApplicationPoolName );
    			if (appPool != null)
    			{
    		      Console.WriteLine($"Found AppPool '{app.ApplicationPoolName}'");
    		      
    			 Console.WriteLine($"    AppPool Child count is {appPool.ChildElements.Count}");
    			 Console.WriteLine($"    AppPool Worker process count is {appPool.WorkerProcesses.Count}");
    				// Console.Write($"Removing AppPool '{app.ApplicationPoolName}'");
    				// serverManager.ApplicationPools.Remove(appPool);
    			}
			}
			serverManager.CommitChanges();
		}
    }
}