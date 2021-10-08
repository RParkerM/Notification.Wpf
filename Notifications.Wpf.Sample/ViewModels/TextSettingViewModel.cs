using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using MathCore.ViewModels;

namespace Notification.Wpf.Sample.ViewModels
{
    public class TextSettingViewModel : ViewModel
    {
        #region Weights : ObservableCollection<FontWeght> - 
        static List<FontWeight> _Weight = new List<FontWeight>()
        {
            FontWeights.Normal,
            FontWeights.Black,
            FontWeights.Bold,
            FontWeights.DemiBold,
            FontWeights.ExtraBlack,
            FontWeights.ExtraBold,
            FontWeights.ExtraLight,
            FontWeights.Heavy,
            FontWeights.Light,
            FontWeights.Medium,
            FontWeights.Regular,
            FontWeights.SemiBold,
            FontWeights.Thin,
            FontWeights.UltraBlack,
            FontWeights.UltraBold,
            FontWeights.UltraLight
        };

        /// <summary></summary>
        private ObservableCollection<FontWeight> _Weights = new ObservableCollection<FontWeight>(_Weight);

        /// <summary></summary>
        public ObservableCollection<FontWeight> Weights { get => _Weights; set => Set(ref _Weights, value); }

        #endregion

        #region Syles : ObservableCollection<FontStyle> - 
        static List<FontStyle> _Style = new List<FontStyle>() { FontStyles.Normal, FontStyles.Italic, FontStyles.Oblique };

        /// <summary></summary>
        private ObservableCollection<FontStyle> _Styles = new ObservableCollection<FontStyle>(_Style);

        /// <summary></summary>
        public ObservableCollection<FontStyle> Styles { get => _Styles; set => Set(ref _Styles, value); }

        #endregion

        #region FontFamilySample : string - 

        /// <summary></summary>
        private FontFamily _FontFamilySample = new FontFamily("Segoe UI");

        /// <summary></summary>
        public FontFamily FontFamilySample { get => _FontFamilySample; set => Set(ref _FontFamilySample, value); }

        #endregion

        #region FontSizeSample : double - 

        /// <summary></summary>
        private double _FontSizeSample = 14;

        /// <summary></summary>
        public double FontSizeSample { get => _FontSizeSample; set => Set(ref _FontSizeSample, value); }

        #endregion

        #region FontStyleSample : FontStyle - 

        /// <summary></summary>
        private FontStyle _FontStyleSample = FontStyles.Normal;

        /// <summary></summary>
        public FontStyle FontStyleSample { get => _FontStyleSample; set => Set(ref _FontStyleSample, value); }

        #endregion

        #region FontWeightSample : FontStyle - 

        /// <summary></summary>
        private FontWeight _FontWeightSample = FontWeights.Normal;

        /// <summary></summary>
        public FontWeight FontWeightSample { get => _FontWeightSample; set => Set(ref _FontWeightSample, value); }

        #endregion

        #region TextAlign : TextAlignment - 

        /// <summary></summary>
        private TextAlignment _TextAlign = TextAlignment.Left;

        /// <summary></summary>
        public TextAlignment TextAlign { get => _TextAlign; set => Set(ref _TextAlign, value); }

        #endregion

        #region HorAlign : HorizontalAlignment - 

        /// <summary></summary>
        private HorizontalAlignment _HorAlign = HorizontalAlignment.Stretch;

        /// <summary></summary>
        public HorizontalAlignment HorAlign { get => _HorAlign; set => Set(ref _HorAlign, value); }

        #endregion

        #region VerAlign : VerticalAlignment - 

        /// <summary></summary>
        private VerticalAlignment _VerAlign = VerticalAlignment.Stretch;

        /// <summary></summary>
        public VerticalAlignment VerAlign { get => _VerAlign; set => Set(ref _VerAlign, value); }

        #endregion

        #region OpacitySample : double - 

        /// <summary></summary>
        private double _OpacitySample = 1D;

        /// <summary></summary>
        public double OpacitySample { get => _OpacitySample; set => Set(ref _OpacitySample, value); }

        #endregion

        #region Text : string - Text

        /// <summary>Text</summary>
        private string _Text;

        /// <summary>Text</summary>
        public string Text { get => _Text; set => Set(ref _Text, value); }

        #endregion

        #region IsActive : bool - IsActive

        /// <summary>IsActive</summary>
        private bool _IsActive;

        /// <summary>IsActive</summary>
        public bool IsActive { get => _IsActive; set => Set(ref _IsActive, value); }

        #endregion

        public TextSettingViewModel()
        {
            FontWeightSample = Weights.First();
            FontStyleSample = Styles.First();
        }
    }
}