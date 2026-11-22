# Deploy XBOXDS4ONE.exe to C:\XBOXDS4ONE\
#
# The source path used to point at a repo-root `publish\` folder that the build
# has not written to for a long time, so every run of this script killed a
# working XBOXDS4ONE, failed the copy, and returned without relaunching it. The
# path now comes off the script's own location and matches where the publish
# step actually puts the single-file exe.
$repo = Split-Path -Parent $PSScriptRoot
# The framework folder comes from the project file, so a .NET upgrade moves
# this path with it instead of leaving it on the last build's exe.
$project = New-Object System.Xml.XmlDocument
$project.Load((Join-Path $repo 'XBOXDS4ONE.App\XBOXDS4ONE.App.csproj'))
$tfm = $project.Project.PropertyGroup |
    ForEach-Object { $_.TargetFramework } | Where-Object { $_ } | Select-Object -First 1
$src = Join-Path $repo "XBOXDS4ONE.App\bin\Release\$tfm\win-x64\publish\XBOXDS4ONE.exe"
$dst = 'C:\XBOXDS4ONE\XBOXDS4ONE.exe'

# Check the source BEFORE stopping anything. Killing the running app and only
# then discovering there is nothing to deploy leaves the machine with no
# XBOXDS4ONE at all, which is worse than not having run the script.
if (-not (Test-Path -LiteralPath $src)) {
    Write-Host "FAILED: no published exe at $src"
    Write-Host "Run the publish step first. XBOXDS4ONE was left running."
    exit 1
}

# Kill any running XBOXDS4ONE
$procs = Get-Process -Name XBOXDS4ONE -ErrorAction SilentlyContinue
if ($procs) {
    $procs | Stop-Process -Force
    for ($i = 0; $i -lt 15; $i++) {
        Start-Sleep -Seconds 1
        if (-not (Get-Process -Name XBOXDS4ONE -ErrorAction SilentlyContinue)) { break }
    }
}

# Extra wait for file handle release
Start-Sleep -Seconds 2

try {
    Copy-Item -LiteralPath $src -Destination $dst -Force -ErrorAction Stop
} catch {
    # The app is already stopped here, so say so rather than leaving the
    # operator to guess whether it is still up.
    Write-Host "FAILED to copy: $($_.Exception.Message)"
    Write-Host "XBOXDS4ONE is stopped. Relaunch $dst by hand or re-run after publishing."
    exit 1
}

Write-Host "Deployed successfully"
Start-Process $dst
Write-Host "XBOXDS4ONE launched"
