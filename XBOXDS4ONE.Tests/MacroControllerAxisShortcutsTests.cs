using System.Linq;
using System.Xml.Linq;
using XBOXDS4ONE.ViewModels;
using Xunit;

namespace XBOXDS4ONE.Tests;

public sealed class MacroControllerAxisShortcutsTests
{
    private static readonly MacroAxisTarget[] Targets =
    {
        MacroAxisTarget.LeftTrigger,
        MacroAxisTarget.RightTrigger,
        MacroAxisTarget.LeftStickX,
        MacroAxisTarget.LeftStickY,
        MacroAxisTarget.RightStickX,
        MacroAxisTarget.RightStickY,
    };

    [Theory]
    [MemberData(nameof(AllTargets))]
    public void ClickingAnAnalogControlAddsASelectedTimedAxisHold(MacroAxisTarget target)
    {
        var macro = new MacroItem();

        macro.AddControllerAxisHoldCommand.Execute(target);

        var action = Assert.Single(macro.Actions);
        Assert.Equal(MacroActionType.AxisHold, action.Type);
        Assert.Equal(target, action.AxisTarget);
        Assert.Equal(short.MaxValue, action.AxisValue);
        Assert.Equal(50, action.DurationMs);
        Assert.Same(action, macro.SelectedAction);
    }

    [Fact]
    public void MacroEditorShowsShortcutsForBothTriggersAndFourStickDirections()
    {
        var page = XDocument.Parse(ExtrasPageTests.RepoText("XBOXDS4ONE.App", "Views", "PadPage.xaml"));
        var parameters = page.Descendants()
            .Where(e => (string)e.Attribute("Command") == "{Binding AddControllerAxisHoldCommand}")
            .Select(e => (string)e.Attribute("CommandParameter"))
            .ToArray();

        Assert.Equal(Targets.Select(target => $"{{x:Static vm:MacroAxisTarget.{target}}}"), parameters);
    }

    public static TheoryData<MacroAxisTarget> AllTargets
    {
        get
        {
            var data = new TheoryData<MacroAxisTarget>();
            foreach (var target in Targets) data.Add(target);
            return data;
        }
    }
}
