#r "C:\Development\site-vacuum\packages\IIS.Microsoft.Web.Administration.8.5.9600.17042\lib\Microsoft.Web.Administration.dll"

using Microsoft.Web.Administration;

using (var serverManager = ServerManager.OpenRemote("localhost"))
{
    foreach( var appPool in serverManager.ApplicationPools )
    {
        bool inUse = false;
    	foreach (var site in serverManager.Sites)
    	{
    	   if ( site.Applications.Any( o => appPool.Name == o.ApplicationPoolName ) )
    	   {
    	       inUse = true;
    	       break;
    	   }
    	}
        Console.WriteLine($"{appPool.Name} inUse is {inUse }");
	}
}