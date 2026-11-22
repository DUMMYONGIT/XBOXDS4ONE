using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;

[assembly: AssemblyTitle("XBOXDS4ONE")]
[assembly: AssemblyDescription("XBOXDS4ONE — Modern controller mapping application.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("XBOXDS4ONE")]
[assembly: AssemblyProduct("XBOXDS4ONE")]
[assembly: AssemblyCopyright("Copyright © XBOXDS4ONE Contributors")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

// The audio/haptic services are internal by convention; the test project
// exercises them (e.g. the #185 mirror engage gate) through this grant.
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("XBOXDS4ONE.Tests")]

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None,
    ResourceDictionaryLocation.SourceAssembly
)]

[assembly: Guid("F0E1D2C3-B4A5-6789-0123-456789ABCDEF")]

// AssemblyVersion + AssemblyFileVersion live in ..\SharedVersion.cs,
// linked into both XBOXDS4ONE.App and XBOXDS4ONE.Engine so the two
// assemblies can never drift apart.
