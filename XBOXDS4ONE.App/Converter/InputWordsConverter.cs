using System;
using System.Globalization;
using System.Windows.Data;

namespace XBOXDS4ONE.Converters
{
    /// <summary>
    /// What a picker of one input reads in its own box while its list holds
    /// no item for it: the saved input in words ("Button 5"), or the empty
    /// word when nothing is saved. Values: the saved descriptor, then the
    /// empty word, which is bound to the strings table so a change of
    /// language reads the box again.
    /// </summary>
    public sealed class InputWordsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string descriptor = values.Length > 0 ? values[0] as string : null;
            string empty = values.Length > 1 ? values[1] as string ?? string.Empty : string.Empty;
            if (string.IsNullOrEmpty(descriptor)) return empty;
            return XBOXDS4ONE.Common.MappingDisplayResolver.ResolveDescriptorText(descriptor,
                Array.Empty<XBOXDS4ONE.Engine.DeviceObjectItem>(), padPrefixAlways: true) ?? descriptor;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
