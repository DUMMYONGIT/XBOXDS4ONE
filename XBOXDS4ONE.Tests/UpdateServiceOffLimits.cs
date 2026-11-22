using System.Runtime.CompilerServices;
using XBOXDS4ONE.Services;

namespace XBOXDS4ONE.Tests
{
    /// <summary>
    /// Keeps the test process from installing, starting, deleting or asking
    /// for anything on this PC through <see cref="UpdateService"/> and
    /// <see cref="UpdateController"/>, for its whole life.
    /// </summary>
    /// <remarks>
    /// The update is tested through stand-ins: arguments the helper cannot
    /// use, a disk of the test's own in place of the real one for the swap,
    /// and the controller's own stand-ins for the network, the pending
    /// record and the helper. A test that gets past its stand-in, or a change
    /// that removes the check in front of the real call, would otherwise
    /// copy the test host over an installed XBOXDS4ONE.exe, delete a pending
    /// record XBOXDS4ONE wrote, take the lease that keeps XBOXDS4ONE from
    /// launching, start XBOXDS4ONE or a browser, or send GitHub a request. With
    /// this set, every process start and request in the two classes refuses,
    /// and so do the lease, the helper's handshake and every write, move and
    /// delete outside the test host's scratch folder. Nothing in the
    /// application sets it (UpdateServiceOffLimitsTests).
    /// </remarks>
    internal static class UpdateServiceOffLimits
    {
#pragma warning disable CA2255 // Only the test host loads this assembly.
        [ModuleInitializer]
        internal static void Set() => UpdateService.OffLimitsForTest = true;
#pragma warning restore CA2255
    }
}
