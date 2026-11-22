# XBOXDS4ONE

![XBOXDS4ONE logo](screenshots/logo.png)

**Controller mapping, macros, and virtual controller output for Windows.**

XBOXDS4ONE is a personal fork of [PadForge](https://github.com/hifihedgehog/PadForge). It builds on PadForge's controller features and adds a broader set of physical controller inputs to the macro trigger picker.

## What it does

- Map physical controller inputs to virtual controller outputs.
- Configure controller profiles and per-device settings.
- Build macros that respond to controller buttons, auxiliary axes, and sliders when the device reports them.
- Use the inherited PadForge tools for motion, touchpad, lighting, audio, and other controller features.

Input availability varies by controller and connection mode. XBOXDS4ONE can only offer inputs exposed by the connected device and input driver.

## Project status

This is an experimental source fork under active development. Check [Releases](https://github.com/DUMMYONGIT/XBOXDS4ONE/releases) for installable builds and release notes.

## Build from source

Build on Windows with the .NET 10 SDK and the Windows SDK components required by the project. See [BUILD.md](BUILD.md) for the full project and native dependency details.

```powershell
dotnet restore XBOXDS4ONE.sln
dotnet build XBOXDS4ONE.sln --no-restore
```

The solution includes the WPF application and supporting libraries and projects. Some features also depend on bundled native components and Windows drivers.

## Upstream project

XBOXDS4ONE is derived from [PadForge](https://github.com/hifihedgehog/PadForge), by the PadForge contributors. For inherited features and setup guidance, see the [PadForge documentation](https://padforge.org/docs/). This personal fork is not affiliated with or endorsed by the upstream maintainers.

## License

The repository's [LICENSE](LICENSE) applies to this fork. The upstream project and its derivative work are licensed under **Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International (CC BY-NC-SA 4.0)**. Changes and redistributed versions must retain appropriate attribution and the same license terms.