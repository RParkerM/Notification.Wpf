using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

using FontAwesome5;

using MathCore.ViewModels;

using Notification.Wpf.Base.Options;
using Notification.Wpf.Classes;
using Notification.Wpf.Constants;
using Notification.Wpf.Controls;

namespace Notification.Wpf.Sample.ViewModels
{
    public class SampleWindowViewModel : ViewModel
    {

        public SampleWindowViewModel()
        {
        }

        #region Text

        #region TitleSettingModel : TextSettingViewModel - Title settings

        /// <summary>Title settings</summary>
        private TextSettingViewModel _TitleSettingModel = new TextSettingViewModel();

        /// <summary>Title settings</summary>
        public TextSettingViewModel TitleSettingModel { get => _TitleSettingModel; set => Set(ref _TitleSettingModel, value); }

        #endregion

        #region MessageSettingModel : TextSettingViewModel - Message settings

        /// <summary>Message settings</summary>
        private TextSettingViewModel _MessageSettingModel = new TextSettingViewModel();

        /// <summary>Message settings</summary>
        public TextSettingViewModel MessageSettingModel { get => _MessageSettingModel; set => Set(ref _MessageSettingModel, value); }

        #endregion

        #endregion

        #region Area settings

        #region ShowXBtn : bool - Show x close button

        /// <summary>Show x close button</summary>
        private bool _ShowXBtn;

        /// <summary>Show x close button</summary>
        public bool ShowXBtn { get => _ShowXBtn; set => Set(ref _ShowXBtn, value); }

        #endregion

        #region Expiration time

        #region ExpirationTime : TimeSpan - Expiration time

        /// <summary>Expiration time</summary>
        private TimeSpan _ExpirationTime;

        /// <summary>Expiration time</summary>
        public TimeSpan ExpirationTime { get => _ExpirationTime; set => Set(ref _ExpirationTime, value); }

        #endregion

        #region UseExpirationTime : bool - Enable time

        /// <summary>Enable time</summary>
        private bool _UseExpirationTime;

        /// <summary>Enable time</summary>
        public bool UseExpirationTime { get => _UseExpirationTime; set => Set(ref _UseExpirationTime, value); }

        #endregion

        #endregion

        #region AreaMinWidth : double - Min Width

        /// <summary>Min Width</summary>
        private double _AreaMinWidth = 350D;

        /// <summary>Min Width</summary>
        public double AreaMinWidth
        {
            get => _AreaMinWidth;
            set
            {
                Set(ref _AreaMinWidth, value);
                NotificationConstants.MinWidth = value;
            }
        }

        #endregion

        #region AreaMaxWidth : double - Max width

        /// <summary>Max width</summary>
        private double _AreaMaxWidth = 350D;

        /// <summary>Max width</summary>
        public double AreaMaxWidth
        {
            get => _AreaMaxWidth;
            set
            {
                Set(ref _AreaMaxWidth, value);
                NotificationConstants.MaxWidth = value;
            }
        }

        #endregion

        #endregion

        #region Window Settings

        #region CollapseProgressIfMoreRows : bool - progress bar automatical collapsing , if messages count more than maximum

        /// <summary>progress bar automatical collapsing , if messages count more than maximum</summary>
        private bool _CollapseProgressIfMoreRows;

        /// <summary>progress bar automatical collapsing , if messages count more than maximum</summary>
        public bool CollapseProgressIfMoreRows
        {
            get => _CollapseProgressIfMoreRows;
            set
            {
                Set(ref _CollapseProgressIfMoreRows, value);
                NotificationConstants.CollapseProgressIfMoreRows = value;
            }
        }

        #endregion
        #region MaxItems : int - Max message stack

        /// <summary>Max message stack</summary>
        private uint _MaxItems = 5;

        /// <summary>Max message stack</summary>
        public uint MaxItems
        {
            get => _MaxItems;
            set
            {
                Set(ref _MaxItems, value);
                NotificationConstants.NotificationsOverlayWindowMaxCount = value;
            }
        }

        #endregion

        #region MessagePosition : NotificationPosition - Message position

        /// <summary>Message position</summary>
        private NotificationPosition _MessagePosition = NotificationPosition.BottomRight;

        /// <summary>Message position</summary>
        public NotificationPosition MessagePosition
        {
            get => _MessagePosition;
            set
            {
                Set(ref _MessagePosition, value);
                NotificationConstants.MessagePosition = value;
            }
        }

        #endregion

        #region ShowInParentWindow : bool - Show messages in parent window

        /// <summary>Show messages in parent window</summary>
        private bool _ShowInParentWindow;

        /// <summary>Show messages in parent window area</summary>
        public bool ShowInParentWindow { get => _ShowInParentWindow; set => Set(ref _ShowInParentWindow, value); }

        #endregion
        #endregion

        #region Notification

        #region SelectedNotificationType : NotificationType - Type of Notification

        /// <summary>Type of Notification</summary>
        private NotificationType _SelectedNotificationType = NotificationType.None;

        /// <summary>Type of Notification</summary>
        public NotificationType SelectedNotificationType { get => _SelectedNotificationType; set => Set(ref _SelectedNotificationType, value); }

        #endregion

        #region SelectedTrimType : NotificationTextTrimType - Text trim type

        /// <summary>Text trim type</summary>
        private NotificationTextTrimType _SelectedTrimType = NotificationTextTrimType.Trim;

        /// <summary>Text trim type</summary>
        public NotificationTextTrimType SelectedTrimType { get => _SelectedTrimType; set => Set(ref _SelectedTrimType, value); }

        #endregion

        #region RowCount : uint - Rows in message

        /// <summary>Rows in message</summary>
        private uint _RowCount;

        /// <summary>Rows in message</summary>
        public uint RowCount { get => _RowCount; set => Set(ref _RowCount, value); }

        #endregion

        #region Buttons

        #region ShowLeftButton : bool - Need left btn

        /// <summary>Need left btn</summary>
        private bool _ShowLeftButton = false;

        /// <summary>Need left btn</summary>
        public bool ShowLeftButton { get => _ShowLeftButton; set => Set(ref _ShowLeftButton, value); }

        #endregion

        #region LeftButtonText : string - Left btn text content

        /// <summary>Left btn text content</summary>
        private string _LeftButtonText = "Ok";

        /// <summary>Left btn text content</summary>
        public string LeftButtonText { get => _LeftButtonText; set => Set(ref _LeftButtonText, value); }

        #endregion

        #region ShowRightButton : bool - Need right btn

        /// <summary>Need right btn</summary>
        private bool _ShowRightButton = true;

        /// <summary>Need right btn</summary>
        public bool ShowRightButton { get => _ShowRightButton; set => Set(ref _ShowRightButton, value); }

        #endregion

        #region RightButtonText : string - Right btn text content

        /// <summary>Right btn text content</summary>
        private string _RightButtonText = "Cancel";

        /// <summary>Right btn text content</summary>
        public string RightButtonText { get => _RightButtonText; set => Set(ref _RightButtonText, value); }

        #endregion

        #endregion

        #region CloseOnClick : bool - Closing messages when Click them

        /// <summary>Closing messages when Click them</summary>
        private bool _CloseOnClick;

        /// <summary>Closing messages when Click them</summary>
        public bool CloseOnClick { get => _CloseOnClick; set => Set(ref _CloseOnClick, value); }

        #endregion


        #region Image

        void OnImageChanged()
        {
            if (!ImageAsIcon && (ImagePosition == ImagePosition.None || ImageSource is null))
                return;
            Image = new NotificationImage()
            {
                Position = ImagePosition,
                Source = ImageSource
            };
        }

        #region Image : NotificationImage - Image

        /// <summary>Image</summary>
        private NotificationImage _Image;

        /// <summary>Image</summary>
        public NotificationImage Image { get => _Image; set => Set(ref _Image, value); }

        #endregion

        #region ImageSource : ImageSource - ImageSource

        /// <summary>ImageSource</summary>
        private ImageSource _ImageSource;

        /// <summary>ImageSource</summary>
        public ImageSource ImageSource
        {
            get => _ImageSource;
            set
            {
                Set(ref _ImageSource, value);
                OnImageChanged();

            }
        }

        #endregion

        #region ImagePosition : ImagePosition - Image position

        /// <summary>Image position</summary>
        private ImagePosition _ImagePosition;

        /// <summary>Image position</summary>
        public ImagePosition ImagePosition
        {
            get => _ImagePosition;
            set
            {
                Set(ref _ImagePosition, value);
                OnImageChanged();
            }
        }

        #endregion

        #region ImageAsIcon : bool - image as Icon

        /// <summary>image as Icon</summary>
        private bool _ImageAsIcon;

        /// <summary>image as Icon</summary>
        public bool ImageAsIcon { get => _ImageAsIcon; set => Set(ref _ImageAsIcon, value); }

        #endregion


        #endregion

        #region Icon section
        private int IconSelectedIndex => (int)(SelectedIcon ?? new SvgAwesome()).Icon;


        #region Icons : ObservableCollection<SvgAwesome> - Icons

        /// <summary>Icons</summary>
        private ObservableCollection<SvgAwesome> _Icons = new ObservableCollection<SvgAwesome>(GetIcons());

        /// <summary>Icons</summary>
        public ObservableCollection<SvgAwesome> Icons { get => _Icons; set => Set(ref _Icons, value); }

        #endregion

        #region SelectedIcon : SvgAwesome - Selected icon

        /// <summary>Selected icon</summary>
        private SvgAwesome _SelectedIcon;

        /// <summary>Selected icon</summary>
        public SvgAwesome SelectedIcon { get => _SelectedIcon; set => Set(ref _SelectedIcon, value); }

        #endregion

        #region IconForeground : SolidColorBrush - Icon color

        /// <summary>Icon color</summary>
        private SolidColorBrush _IconForeground = new SolidColorBrush(Colors.WhiteSmoke);

        /// <summary>Icon color</summary>
        public SolidColorBrush IconForeground { get => _IconForeground; set => Set(ref _IconForeground, value); }

        #endregion

        private static IEnumerable<SvgAwesome> GetIcons()
        {
            var icons = Enum.GetValues<EFontAwesomeIcon>().Select(s => new SvgAwesome() { Icon = s, Height = 20 });
            var progress_icon = NotificationConstants.DefaultProgressIcon;
            progress_icon.Foreground = Brushes.Black;

            var result = new List<SvgAwesome>(new[] { icons.First(), progress_icon });
            result.AddRange(icons.Skip(1));
            return result;
        }
        private object GetIcon(bool isProgress = false)
        {
            var type = SelectedNotificationType;
            var isNone = type == NotificationType.None || isProgress;
            var selected_icon = (EFontAwesomeIcon)(int)(SelectedIcon ?? new SvgAwesome()).Icon;

            if (ImageAsIcon)
                return Image;

            if (isNone && IconSelectedIndex == 0)
                return null;

            if (IconSelectedIndex == 806)
                return new SvgAwesome()
                {
                    Icon = selected_icon,
                    Height = 25,
                    Foreground = IconForeground,
                    Spin = true,
                    SpinDuration = 1
                };
            return new SvgAwesome()
            {
                Icon = selected_icon,
                Height = 25,
                Foreground = IconForeground
            };
        }

        #endregion

        #region Colors

        #region ContentForeground : SolidColorBrush - Foreground

        /// <summary>Foreground</summary>
        private SolidColorBrush _ContentForeground = new SolidColorBrush(Colors.WhiteSmoke);

        /// <summary>Foreground</summary>
        public SolidColorBrush ContentForeground { get => _ContentForeground; set => Set(ref _ContentForeground, value); }

        #endregion

        #region ContentBackground : SolidColorBrush - Background

        /// <summary>Foreground</summary>
        private SolidColorBrush _ContentBackground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF444444");

        /// <summary>Foreground</summary>
        public SolidColorBrush ContentBackground { get => _ContentBackground; set => Set(ref _ContentBackground, value); }

        #endregion

        #endregion
        #endregion

        #region Progress

        #region ProgressColor : SolidColorBrush 

        /// <summary>Progress line color</summary>
        private SolidColorBrush _ProgressColor = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF01D328");

        /// <summary>Progress line color</summary>
        public SolidColorBrush ProgressColor { get => _ProgressColor; set => Set(ref _ProgressColor, value); }

        #endregion

        #region ProgressCollapsed : bool - collapsed progress bar style

        /// <summary>collapsed progress bar style</summary>
        private bool _ProgressCollapsed;

        /// <summary>collapsed progress bar style</summary>
        public bool ProgressCollapsed { get => _ProgressCollapsed; set => Set(ref _ProgressCollapsed, value); }

        #endregion

        #region ProgressTitleOrMessage : bool - Title or message when collapsed

        /// <summary>Title or message when collapsed</summary>
        private bool _ProgressTitleOrMessage;

        /// <summary>Title or message when collapsed</summary>
        public bool ProgressTitleOrMessage { get => _ProgressTitleOrMessage; set => Set(ref _ProgressTitleOrMessage, value); }

        #endregion
        #endregion
    }
}
