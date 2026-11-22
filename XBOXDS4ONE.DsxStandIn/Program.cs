// DSX.exe, XBOXDS4ONE's stand-in for DSX game mods (#529).
//
// Some mods made for DSX look for a running process named DSX and turn
// themselves off without one: DualSense4GTAV checks
// Process.GetProcessesByName("DSX") on every lights tick (iO.cs:61). While
// XBOXDS4ONE's game mod server listens with Run a DSX.exe Stand-In on, XBOXDS4ONE
// starts this program under that name. It waits for the XBOXDS4ONE that started
// it to exit and then exits too. XBOXDS4ONE also ends it when the server stops,
// and a job object ends it if XBOXDS4ONE itself ends first.
using System;
using System.ComponentModel;
using System.Diagnostics;

internal static class Program
{
    private static int Main(string[] args)
    {
        int parent;
        if (args.Length < 1 || !int.TryParse(args[0], out parent)) return 1;
        try
        {
            using (var process = Process.GetProcessById(parent))
                process.WaitForExit();
        }
        catch (ArgumentException) { }          // XBOXDS4ONE is already gone.
        catch (InvalidOperationException) { }
        catch (Win32Exception) { }
        return 0;
    }
}
