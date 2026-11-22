using System;
using System.Linq;
using System.Reflection;
using System.Windows.Interop;
using XBOXDS4ONE.Common.Input.Flydigi;
using XBOXDS4ONE.Views;
using Xunit;

namespace XBOXDS4ONE.Tests
{
    /// <summary>
    /// The Flydigi screen dialog (#586) made whole, on the test host's
    /// stand-in application.
    /// </summary>
    [Collection("WpfApplicationSingleton")]
    public class FlydigiScreenDialogTests
    {
        /// <summary>The constructor picks the first source and fit, and each
        /// pick builds the preview, which stops the preview's timer. The
        /// timer has to exist before the first pick: made after it, the
        /// constructor threw and the dialog never opened.</summary>
        [Fact]
        public void TheDialogOpens() => DialogTestHost.Run(() =>
        {
            var ctor = typeof(FlydigiScreenDialog).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).Single();
            var binding = new FlydigiScreenSender.Apex4Binding();
            var dialog = (FlydigiScreenDialog)ctor.Invoke(new object[] { Guid.NewGuid(), XBOXDS4ONE.Engine.Flydigi.FlydigiApexModel.Apex4,
                binding, "Racing", 2, null });
            try
            {
                new WindowInteropHelper(dialog).EnsureHandle();
                Assert.NotNull(dialog.FindName("SourceBox"));
            }
            finally
            {
                dialog.Close();
            }
        });
    }
}
