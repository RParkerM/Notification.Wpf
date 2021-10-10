using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Notification.Wpf.Sample.Helpers
{
    public class NotificationLineHeightBehavior
    {
        public static readonly DependencyProperty MaxLinesProperty =
            DependencyProperty.RegisterAttached(
                "MaxLines",
                typeof(int),
                typeof(NotificationLineHeightBehavior),
                new PropertyMetadata(default(int), OnMaxLinesPropertyChangedCallback));

        public static void SetMaxLines(TextBlock element, int value) => element.SetValue(MaxLinesProperty, value);

        public static int GetMaxLines(TextBlock element) => (int)element.GetValue(MaxLinesProperty);

        private static void OnMaxLinesPropertyChangedCallback(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBlock textBlock)
            {
                if (textBlock.IsLoaded)
                {
                    SetLineHeight();
                }
                else
                {
                    textBlock.Loaded += OnLoaded;

                    void OnLoaded(object _, RoutedEventArgs __)
                    {
                        textBlock.Loaded -= OnLoaded;
                        SetLineHeight();
                    }
                }

                void SetLineHeight()
                {
                    double lineHeight =
                        double.IsNaN(textBlock.LineHeight)
                            ? textBlock.FontFamily.LineSpacing * textBlock.FontSize
                            : textBlock.LineHeight;
                    textBlock.MaxHeight = Math.Ceiling(lineHeight * GetMaxLines(textBlock));
                }
            }
        }
    }
}
