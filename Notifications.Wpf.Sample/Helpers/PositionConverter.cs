using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using MathCore.WPF.Converters;
using Notification.Wpf.Controls;

namespace Notification.Wpf.Sample.Helpers
{
    [ValueConversion(typeof(NotificationPosition), typeof(VerticalAlignment)), MarkupExtensionReturnType(typeof(VerticalPositionConverter))]
    internal class VerticalPositionConverter : ValueConverter
    {
        protected override object Convert(object v, Type t, object p, CultureInfo c)
        {
            if (v is not NotificationPosition pos)
                return Binding.DoNothing;
            return pos switch
            {
                NotificationPosition.BottomRight => VerticalAlignment.Bottom,
                NotificationPosition.TopRight => VerticalAlignment.Top,
                NotificationPosition.BottomLeft => VerticalAlignment.Bottom,
                NotificationPosition.TopLeft => VerticalAlignment.Top,
                NotificationPosition.BottomCenter => VerticalAlignment.Bottom,
                NotificationPosition.TopCenter => VerticalAlignment.Top,
                _ => throw new ArgumentOutOfRangeException()
            };
        }


        protected override object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotSupportedException();

    }
    [ValueConversion(typeof(NotificationPosition), typeof(HorizontalAlignment)), MarkupExtensionReturnType(typeof(HorizontalPositionConverter))]
    internal class HorizontalPositionConverter : ValueConverter
    {
        protected override object Convert(object v, Type t, object p, CultureInfo c)
        {
            if (v is not NotificationPosition pos)
                return Binding.DoNothing;
            return pos switch
            {
                NotificationPosition.BottomRight => HorizontalAlignment.Right,
                NotificationPosition.TopRight => HorizontalAlignment.Right,
                NotificationPosition.BottomLeft => HorizontalAlignment.Left,
                NotificationPosition.TopLeft => HorizontalAlignment.Left,
                NotificationPosition.BottomCenter => HorizontalAlignment.Center,
                NotificationPosition.TopCenter => HorizontalAlignment.Center,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        protected override object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotSupportedException();

    }

}
