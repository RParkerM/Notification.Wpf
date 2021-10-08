using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Notification.Wpf.Sample.ViewModels;

namespace Notification.Wpf.Sample.Elements
{
    /// <summary>
    /// Логика взаимодействия для TextSettings.xaml
    /// </summary>
    public partial class TextSettings : UserControl
    {
        public TextSettings()
        {
            InitializeComponent();
            this.DataContext = new TextSettingViewModel();
            ////StyleBox.ItemsSource = Styles;
            ////StyleBox.SelectedIndex = 1;
            ////WeightBox.ItemsSource = _Weight;
            ////WeightBox.SelectedIndex = 1;

            //FontFamilySample = FontFamily.Source;
            //FontSizeSample = 14D;
            //if (StyleBox.ItemsSource is IEnumerable<FontStyle> styles)
            //    FontStyleSample = styles.First();
            //if (WeightBox.ItemsSource is IEnumerable<FontWeight> weight)
            //    FontWeightSample = weight.First();
            //TextAlign = TextAlignment.Left;
            //HorAlign = HorizontalAlignment.Stretch;
            //VerAlign = VerticalAlignment.Stretch;
            //OpacitySample = 1D;
        }

        //#region Styles : List<FontStyle> -

        //static List<FontStyle> _Styles = new List<FontStyle>() { FontStyles.Normal, FontStyles.Italic, FontStyles.Oblique };
        ///// <summary></summary>
        //public static readonly DependencyProperty StylesProperty =
        //    DependencyProperty.Register(
        //        nameof(Styles),
        //        typeof(List<FontStyle>),
        //        typeof(TextSettings),
        //        new PropertyMetadata(default));

        ///// <summary></summary>
        //public List<FontStyle> Styles { get => (List<FontStyle>)GetValue(StylesProperty); set => SetValue(StylesProperty, value); }

        //#endregion

        //#region Weight : List<FontWeight> - 
        //static List<FontWeight> _Weight = new List<FontWeight>()
        //{
        //    FontWeights.Normal,
        //    FontWeights.Black,
        //    FontWeights.Bold,
        //    FontWeights.DemiBold,
        //    FontWeights.ExtraBlack,
        //    FontWeights.ExtraBold,
        //    FontWeights.ExtraLight,
        //    FontWeights.Heavy,
        //    FontWeights.Light,
        //    FontWeights.Medium,
        //    FontWeights.Regular,
        //    FontWeights.SemiBold,
        //    FontWeights.Thin,
        //    FontWeights.UltraBlack,
        //    FontWeights.UltraBold,
        //    FontWeights.UltraLight
        //};
        ///// <summary></summary>
        //public static readonly DependencyProperty WeightProperty =
        //    DependencyProperty.Register(
        //        nameof(Weight),
        //        typeof(List<FontWeight>),
        //        typeof(TextSettings),
        //        new PropertyMetadata(default));

        ///// <summary></summary>
        //public List<FontWeight> Weight { get => (List<FontWeight>)GetValue(WeightProperty); set => SetValue(WeightProperty, value); }

        //#endregion

        //#region FontFamilySample : string - 

        ///// <summary></summary>
        //public static readonly DependencyProperty FontFamilySampleProperty =
        //    DependencyProperty.Register(
        //        nameof(FontFamilySample),
        //        typeof(string),
        //        typeof(TextSettings),
        //        new PropertyMetadata(default));

        ///// <summary></summary>
        //public string FontFamilySample { get => (string)GetValue(FontFamilySampleProperty); set => SetValue(FontFamilySampleProperty, value); }

        //#endregion

        //#region FontSizeSample : double - 

        ///// <summary></summary>
        //public static readonly DependencyProperty FontSizeSampleProperty =
        //    DependencyProperty.Register(
        //        nameof(FontSizeSample),
        //        typeof(double),
        //        typeof(TextSettings),
        //        new PropertyMetadata(default));

        ///// <summary></summary>
        //public double FontSizeSample { get => (double)GetValue(FontSizeSampleProperty); set => SetValue(FontSizeSampleProperty, value); }

        //#endregion

        //#region FontStyleSample : FontStyle - 

        ///// <summary></summary>
        //public static readonly DependencyProperty FontStyleSampleProperty =
        //    DependencyProperty.Register(
        //        nameof(FontStyleSample),
        //        typeof(FontStyle),
        //        typeof(TextSettings),
        //        new PropertyMetadata(default));

        ///// <summary></summary>
        //public FontStyle FontStyleSample { get => (FontStyle)GetValue(FontStyleSampleProperty); set => SetValue(FontStyleSampleProperty, value); }

        //#endregion

        //#region FontWeightSample : FontWeight - 

        ///// <summary></summary>
        //public static readonly DependencyProperty FontWeightSampleProperty =
        //    DependencyProperty.Register(
        //        nameof(FontWeightSample),
        //        typeof(FontWeight),
        //        typeof(TextSettings),
        //        new PropertyMetadata(default));

        ///// <summary></summary>
        //public FontWeight FontWeightSample { get => (FontWeight)GetValue(FontWeightSampleProperty); set => SetValue(FontWeightSampleProperty, value); }

        //#endregion

        //#region TextAlign : TextAlignment - Выравнивание текста

        ///// <summary>Выравнивание текста</summary>
        //public static readonly DependencyProperty TextAlignProperty =
        //    DependencyProperty.Register(
        //        nameof(TextAlign),
        //        typeof(TextAlignment),
        //        typeof(TextSettings),
        //        new PropertyMetadata(default));

        ///// <summary>Выравнивание текста</summary>
        //public TextAlignment TextAlign { get => (TextAlignment)GetValue(TextAlignProperty); set => SetValue(TextAlignProperty, value); }

        //#endregion

        //#region HorAlign : HorizontalAlignment - 

        ///// <summary></summary>
        //public static readonly DependencyProperty HorAlignProperty =
        //    DependencyProperty.Register(
        //        nameof(HorAlign),
        //        typeof(HorizontalAlignment),
        //        typeof(TextSettings),
        //        new PropertyMetadata(default));

        ///// <summary></summary>
        //public HorizontalAlignment HorAlign { get => (HorizontalAlignment)GetValue(HorAlignProperty); set => SetValue(HorAlignProperty, value); }

        //#endregion

        //#region VerAlign : VerticalAlignment - 

        ///// <summary></summary>
        //public static readonly DependencyProperty VerAlignProperty =
        //    DependencyProperty.Register(
        //        nameof(VerAlign),
        //        typeof(VerticalAlignment),
        //        typeof(TextSettings),
        //        new PropertyMetadata(default));

        ///// <summary></summary>
        //public VerticalAlignment VerAlign { get => (VerticalAlignment)GetValue(VerAlignProperty); set => SetValue(VerAlignProperty, value); }

        //#endregion

        //#region OpacitySample : double - 

        ///// <summary></summary>
        //public static readonly DependencyProperty OpacitySampleProperty =
        //    DependencyProperty.Register(
        //        nameof(OpacitySample),
        //        typeof(double),
        //        typeof(TextSettings),
        //        new PropertyMetadata(default));

        ///// <summary></summary>
        //public double OpacitySample { get => (double)GetValue(OpacitySampleProperty); set => SetValue(OpacitySampleProperty, value); }

        //#endregion
    }
}
