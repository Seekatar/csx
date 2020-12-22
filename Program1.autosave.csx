using Microsoft.Win32;

var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall", false);

var v1 = reg.GetSubKeyNames().Where(o => o.StartsWith("VersionOne")).SingleOrDefault();
var v1Key = reg.OpenSubKey(v1);
v1Key.GetValue("UninstallString")