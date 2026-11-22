# XBOXDS4ONE

![XBOXDS4ONE logo](screenshots/logo.png)

A personal Windows controller-mapping fork based on [PadForge](https://github.com/hifihedgehog/PadForge).

This fork focuses on making more of a controller's reported inputs available in macro triggers and adding a hold action for virtual controller buttons.

## Macro changes

- **More trigger inputs:** the macro trigger picker can include raw controller buttons, auxiliary axes such as Axis 6 and higher, and sliders when the device reports them.
- **Hold Button While Active:** keeps selected virtual controller buttons pressed for as long as the macro is active. The output releases when the trigger is released or the macro stops.

Available controls depend on the controller and how XBOXDS4ONE reports its inputs.

## Project status

This is an experimental source fork. The macro changes are committed locally, but the full application build and test suite have not completed in the current environment. No installable release or ready-made .exe is published here yet.

See [BUILD.md](BUILD.md) for build details. A Windows SDK installation is required in addition to the .NET 10 SDK for the WPF application build.

## Using the fork

The app builds on the PadForge project. See the [upstream PadForge project](https://github.com/hifihedgehog/PadForge) and its [documentation](https://padforge.org/docs/) for inherited features and setup guidance.

## Build

This repository targets Windows and .NET 10. After installing the .NET 10 SDK and the Windows SDK, restore and build the solution:

    dotnet restore XBOXDS4ONE.sln
    dotnet build XBOXDS4ONE.sln --no-restore

Build output and runtime behavior have not yet been verified for this fork.

## Attribution and license

XBOXDS4ONE is derived from [PadForge](https://github.com/hifihedgehog/PadForge), by the PadForge contributors. This fork is not affiliated with or endorsed by the upstream maintainers.

The repository's [LICENSE](LICENSE) applies to this fork. The upstream project and its derivative work are licensed under **Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International (CC BY-NC-SA 4.0)**. Changes and redistributed versions must retain appropriate attribution and the same license terms.