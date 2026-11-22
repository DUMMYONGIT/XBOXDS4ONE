using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// The wire codecs' framing internals (device-list encode/decode) are
// pinned by tests so a layout change can never ship silently.
[assembly: InternalsVisibleTo("XBOXDS4ONE.Tests")]

[assembly: AssemblyTitle("XBOXDS4ONE.Engine")]
[assembly: AssemblyDescription("XBOXDS4ONE input engine — SDL3, Raw Input, and HID device enumeration.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("XBOXDS4ONE")]
[assembly: AssemblyProduct("XBOXDS4ONE")]
[assembly: AssemblyCopyright("Copyright © XBOXDS4ONE Contributors")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("A1B2C3D4-E5F6-7890-ABCD-EF1234567890")]

// AssemblyVersion + AssemblyFileVersion live in ..\SharedVersion.cs,
// linked into both XBOXDS4ONE.App and XBOXDS4ONE.Engine so the two
// assemblies can never drift apart.
