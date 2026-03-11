using static System.Console;

ushort j = 0;
ushort k = 1025;
for (ulong i = 0; i < 100000; i++ )
{
    j += 1;
    if (j % k == 0)
        WriteLine($"{j} {Math.Floor((double)j / k)} {j % k}");
}