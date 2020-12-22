using static System.Console;
var args = "-noprofile -c cd \\temp; dir";
var command = "powershell";

ProcessStartInfo psi = new ProcessStartInfo(command, args)
{
    CreateNoWindow = false
};

Process p = Process.Start(psi);
p.WaitForExit();
WriteLine($"Exit code is {p.ExitCode}");

args = "-noprofile -c pwd";
psi = new ProcessStartInfo(command, args)
{
    CreateNoWindow = false
};
p = Process.Start(psi);
p.WaitForExit();
WriteLine($"Exit code is {p.ExitCode}");

Console.WriteLine("Yo!");