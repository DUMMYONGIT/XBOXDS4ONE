using System.Linq;
using PadForge.ViewModels;
using Xunit;

namespace PadForge.Tests;

public sealed class MacroTriggerExtendedControlTests
{
    [Theory]
    [InlineData("Button 0")]
    [InlineData("Button 27")]
    public void TriggerPicker_ConvertsRawButtons(string descriptor)
    {
        var choice = new InputChoice { Descriptor = descriptor };

        Assert.True(MacroItem.TryBuildTriggerEntry(choice, out var entry));
        Assert.Equal(int.Parse(descriptor.Substring("Button ".Length)), entry.RawButton);
    }

    [Fact]
    public void TriggerPicker_UsesDescriptorForAuxiliaryAxis()
    {
        const string descriptor = "Axis 6";
        var choice = new InputChoice { Descriptor = descriptor };

        Assert.True(MacroItem.TryBuildTriggerEntry(choice, out var entry));
        Assert.Equal(descriptor, entry.SourceDescriptor);
        Assert.Equal(MacroAxisTarget.None, entry.AxisTarget);
        Assert.Equal(entry.Spec, MacroItem.TriggerInputEntry.Parse(entry.Spec).Spec);
    }

    [Fact]
    public void TriggerPicker_UsesDescriptorForSlider()
    {
        const string descriptor = "Slider 0";
        var choice = new InputChoice { Descriptor = descriptor };

        Assert.True(MacroItem.TryBuildTriggerEntry(choice, out var entry));
        Assert.Equal(descriptor, entry.SourceDescriptor);
        Assert.Equal(entry.Spec, MacroItem.TriggerInputEntry.Parse(entry.Spec).Spec);
    }

    [Fact]
    public void HoldButtonAction_IsSelectableAndOffersButtonTargets()
    {
        var action = new MacroAction { Type = MacroActionType.HoldVcButtonWhileHeld };
        var choice = Assert.Single(MacroTypeCatalog.Choices,
            item => item.Type == MacroActionType.HoldVcButtonWhileHeld);

        Assert.True(action.IsAnyVcButtonType);
        Assert.NotEmpty(action.ButtonOptions);
        Assert.False(string.IsNullOrWhiteSpace(choice.Label));
        Assert.False(string.IsNullOrWhiteSpace(choice.Tooltip));
    }
}
