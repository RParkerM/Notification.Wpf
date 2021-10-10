using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using FontAwesome5;

using MathCore.ViewModels;
using MathCore.WPF.Commands;

using Microsoft.Win32;

using Notification.Wpf.Base;
using Notification.Wpf.Base.Options;
using Notification.Wpf.Classes;
using Notification.Wpf.Constants;
using Notification.Wpf.Controls;
using Notification.Wpf.View;

using Notifications.Wpf.ViewModels;

using Notification = Notification.Wpf.Controls.Notification;

namespace Notification.Wpf.Sample.ViewModels
{
    public class SampleWindowViewModel : ViewModel
    {
        private readonly NotificationManager _notificationManager = new();

        Action ButtonClick(string button) => () => _notificationManager.Show($"{button} button click",areaName:GetArea());

        #region Notification : NotificationContent - Модель сообщения

        /// <summary>Модель сообщения</summary>
        private Controls.Notification _Notification;

        /// <summary>Модель сообщения</summary>
        public Controls.Notification Notification
        {
            get => _Notification;
            set => Set(ref _Notification, value);
        }

        #endregion

        #region ImageNotification : Controls - Image

        /// <summary>Image</summary>
        private Controls.Notification _ImageNotification;

        /// <summary>Image</summary>
        public Controls.Notification ImageNotification { get => _ImageNotification; set => Set(ref _ImageNotification, value); }

        #endregion

        #region ProgressNotification : NotificationProgress - progress

        /// <summary>progress</summary>
        private Controls.Notification _ProgressNotification;

        /// <summary>progress</summary>
        public Controls.Notification ProgressNotification { get => _ProgressNotification; set => Set(ref _ProgressNotification, value); }

        #endregion

        public SampleWindowViewModel()
        {
            TitleSettingModel.PropertyChanged += (Sender, Args) => SetContent();
            MessageSettingModel.PropertyChanged += (Sender, Args) => SetContent();

            OpenImageCommand = Command.New(OpenImage);
            ShowTestMessageCommand = Command.New(TestMessage);
            ShowTimerMessageCommand = Command.New(Button_Timer);
            ShowProgressMessageCommand = Command.New(Progress_Click);
            ShowContentCommand = Command.New(Show_Any_content);

            Timer = new Timer { Interval = 1000 };
            Timer.Elapsed += (_, _) => Dispatcher.CurrentDispatcher.Invoke(() => _notificationManager.Show("Pink string from another thread!", areaName: GetArea()));

        }
        private string GetArea() => ShowInParentWindow ? "WindowArea" : "";

        private NotificationContent GetContent(bool isProgress = false)
        {
            var type = SelectedNotificationType;
            var isNone = type == NotificationType.None;

            var content = new NotificationContent()
            {
                Title = TitleSettingModel.Text,
                Message = MessageSettingModel.Text,

                Type = type,
                Image = Image,
                CloseOnClick = CloseOnClick,


                LeftButtonAction = ShowLeftButton ? ButtonClick("Left") : null,
                LeftButtonContent = LeftButtonText ?? NotificationConstants.DefaultLeftButtonContent,
                RightButtonAction = ShowRightButton ? ButtonClick("Right") : null,
                RightButtonContent = RightButtonText ?? NotificationConstants.DefaultRightButtonContent,


                Background = isNone ? new SolidColorBrush(ContentBackground) : null,
                Foreground = isNone ? new SolidColorBrush(ContentForeground) : null,
                Icon = GetIcon(isProgress),
                MessageTextSettings = MessageSettingModel.IsActive ? MessageSettingModel.TextSetting : null,
                TitleTextSettings = TitleSettingModel.IsActive ? TitleSettingModel.TextSetting : null,
                RowsCount = RowCount is { } count and > 0 ? count : 1,
                TrimType = SelectedTrimType
            };

            return content;
        }

        private void UpdateNotificationArea() { Notification = new Controls.Notification(GetContent(), ShowXBtn); }

        private void UpdateImageArea()
        {
            ImageNotification = new Controls.Notification(ImageSource, ShowXBtn);
        }
        private void UpdateProgressArea()
        {
            ICustomizedNotification content = GetContent(true);
            var model = new NotificationProgressViewModel(content,
                ShowCancelButton,
                ShowProgress,
                UseWaitingMessage ? BaseWaitingMessage : "",
                ProgressCollapsed,
                ProgressTitleOrMessage,
                new SolidColorBrush(ProgressColor))
            { process = ProgressValue, ShowProgress = ShowProgress};
            NotificationProgress progress = new NotificationProgress() { DataContext = model };
            ProgressNotification = new Controls.Notification(progress, ShowXBtn);
            SetProgressValue(ProgressValue);
        }
        private void SetContent()
        {
            UpdateNotificationArea();

            UpdateImageArea();

            UpdateProgressArea();
        }

        #region Text

        #region TitleSettingModel : TextSettingViewModel - Title settings

        /// <summary>Title settings</summary>
        private TextSettingViewModel _TitleSettingModel = new TextSettingViewModel();

        /// <summary>Title settings</summary>
        public TextSettingViewModel TitleSettingModel
        {
            get => _TitleSettingModel;
            set
            {
                Set(ref _TitleSettingModel, value);
                SetContent();
            }
        }

        #endregion

        #region MessageSettingModel : TextSettingViewModel - Message settings

        /// <summary>Message settings</summary>
        private TextSettingViewModel _MessageSettingModel = new TextSettingViewModel();

        /// <summary>Message settings</summary>
        public TextSettingViewModel MessageSettingModel
        {
            get => _MessageSettingModel;
            set
            {
                Set(ref _MessageSettingModel, value);
                SetContent();
            }
        }

        #endregion

        #endregion

        #region Area settings

        #region ShowXBtn : bool - Show x close button

        /// <summary>Show x close button</summary>
        private bool _ShowXBtn;

        /// <summary>Show x close button</summary>
        public bool ShowXBtn
        {
            get => _ShowXBtn;
            set
            {
                Set(ref _ShowXBtn, value);
                SetContent();
            }
        }

        #endregion

        #region Expiration time

        #region ExpirationTime : TimeSpan - Expiration time

        private TimeSpan Seconds => UseExpirationTime ? TimeSpan.FromSeconds(ExpirationTime) : TimeSpan.MaxValue;
        /// <summary>Expiration time</summary>
        private int _ExpirationTime = 3;

        /// <summary>Expiration time</summary>
        public int ExpirationTime
        {
            get => _ExpirationTime;
            set
            {
                Set(ref _ExpirationTime, value);
                SetContent();
            }
        }

        #endregion

        #region UseExpirationTime : bool - Enable time

        /// <summary>Enable time</summary>
        private bool _UseExpirationTime;

        /// <summary>Enable time</summary>
        public bool UseExpirationTime
        {
            get => _UseExpirationTime;
            set
            {
                Set(ref _UseExpirationTime, value);
                SetContent();
            }
        }

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
                SetContent();
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
                SetContent();
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
                SetContent();
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
                SetContent();
                NotificationConstants.NotificationsOverlayWindowMaxCount = value;
            }
        }

        #endregion

        #region MessagePosition : NotificationPosition - Message position

        /// <summary>Message position</summary>
        private NotificationPosition _MessagePosition = NotificationPosition.BottomCenter;

        /// <summary>Message position</summary>
        public NotificationPosition MessagePosition
        {
            get => _MessagePosition;
            set
            {
                Set(ref _MessagePosition, value);
                SetContent();
                NotificationConstants.MessagePosition = value;
            }
        }

        #endregion

        #region ShowInParentWindow : bool - Show messages in parent window

        /// <summary>Show messages in parent window</summary>
        private bool _ShowInParentWindow;

        /// <summary>Show messages in parent window area</summary>
        public bool ShowInParentWindow
        {
            get => _ShowInParentWindow;
            set
            {
                Set(ref _ShowInParentWindow, value);
                SetContent();
            }
        }

        #endregion
        #endregion

        #region Notification

        #region SelectedNotificationType : NotificationType - Type of Notification

        /// <summary>Type of Notification</summary>
        private NotificationType _SelectedNotificationType = NotificationType.None;

        /// <summary>Type of Notification</summary>
        public NotificationType SelectedNotificationType
        {
            get => _SelectedNotificationType;
            set
            {
                Set(ref _SelectedNotificationType, value);
                SetContent();
            }
        }

        #endregion

        #region SelectedTrimType : NotificationTextTrimType - Text trim type

        /// <summary>Text trim type</summary>
        private NotificationTextTrimType _SelectedTrimType = NotificationTextTrimType.Trim;

        /// <summary>Text trim type</summary>
        public NotificationTextTrimType SelectedTrimType
        {
            get => _SelectedTrimType;
            set
            {
                Set(ref _SelectedTrimType, value);
                SetContent();
            }
        }

        #endregion

        #region RowCount : uint - Rows in message

        /// <summary>Rows in message</summary>
        private uint _RowCount = 1;

        /// <summary>Rows in message</summary>
        public uint RowCount
        {
            get => _RowCount;
            set
            {
                Set(ref _RowCount, value);
                SetContent();
            }
        }

        #endregion

        #region Buttons

        #region ShowLeftButton : bool - Need left btn

        /// <summary>Need left btn</summary>
        private bool _ShowLeftButton = false;

        /// <summary>Need left btn</summary>
        public bool ShowLeftButton
        {
            get => _ShowLeftButton;
            set
            {
                Set(ref _ShowLeftButton, value);
                SetContent();
            }
        }

        #endregion

        #region LeftAction : Action - Left Action

        /// <summary>Left Action</summary>
        private Action _LeftAction;

        /// <summary>Left Action</summary>
        public Action LeftAction
        {
            get => _LeftAction;
            set
            {
                Set(ref _LeftAction, value);
                SetContent();
            }
        }

        #endregion
        #region RightAction : Action - Right Action

        /// <summary>Right Action</summary>
        private Action _RightAction;

        /// <summary>Right Action</summary>
        public Action RightAction
        {
            get => _RightAction;
            set
            {
                Set(ref _RightAction, value);
                SetContent();
            }
        }

        #endregion

        #region LeftButtonText : string - Left btn text content

        /// <summary>Left btn text content</summary>
        private string _LeftButtonText = "Ok";

        /// <summary>Left btn text content</summary>
        public string LeftButtonText
        {
            get => _LeftButtonText;
            set
            {
                Set(ref _LeftButtonText, value);
                SetContent();
            }
        }

        #endregion

        #region ShowRightButton : bool - Need right btn

        /// <summary>Need right btn</summary>
        private bool _ShowRightButton = true;

        /// <summary>Need right btn</summary>
        public bool ShowRightButton
        {
            get => _ShowRightButton;
            set
            {
                Set(ref _ShowRightButton, value);
                SetContent();
            }
        }

        #endregion

        #region RightButtonText : string - Right btn text content

        /// <summary>Right btn text content</summary>
        private string _RightButtonText = "Cancel";

        /// <summary>Right btn text content</summary>
        public string RightButtonText
        {
            get => _RightButtonText;
            set
            {
                Set(ref _RightButtonText, value);
                SetContent();
            }
        }

        #endregion

        #endregion

        #region CloseOnClick : bool - Closing messages when Click them

        /// <summary>Closing messages when Click them</summary>
        private bool _CloseOnClick;

        /// <summary>Closing messages when Click them</summary>
        public bool CloseOnClick
        {
            get => _CloseOnClick;
            set
            {
                Set(ref _CloseOnClick, value);
                SetContent();
            }
        }

        #endregion


        #region Image

        void OnImageChanged()
        {
            if (!ImageAsIcon && (ImagePosition == ImagePosition.None || ImageSource is null))
            {
                Image = null;
                return;
            }
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
        public NotificationImage Image
        {
            get => _Image;
            set
            {
                Set(ref _Image, value);
                SetContent();
            }
        }

        #endregion

        #region ImageSource : ImageSource - ImageSource

        /// <summary>ImageSource</summary>
        private ImageSource _ImageSource = new BitmapImage(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Test image.png")));

        /// <summary>ImageSource</summary>
        public ImageSource ImageSource
        {
            get => _ImageSource;
            set
            {
                Set(ref _ImageSource, value);
                OnImageChanged();
                SetContent();
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
                SetContent();
            }
        }

        #endregion

        #region ImageAsIcon : bool - image as Icon

        /// <summary>image as Icon</summary>
        private bool _ImageAsIcon;

        /// <summary>image as Icon</summary>
        public bool ImageAsIcon
        {
            get => _ImageAsIcon;
            set
            {
                Set(ref _ImageAsIcon, value);
                SetContent();
            }
        }

        #endregion


        #endregion

        #region Icon section
        private int IconSelectedIndex => (int)(SelectedIcon ?? new SvgAwesome()).Icon;


        #region Icons : ObservableCollection<SvgAwesome> - Icons

        /// <summary>Icons</summary>
        private ObservableCollection<SvgAwesome> _Icons = new ObservableCollection<SvgAwesome>(GetIcons());

        /// <summary>Icons</summary>
        public ObservableCollection<SvgAwesome> Icons
        {
            get => _Icons;
            set
            {
                Set(ref _Icons, value);
                SetContent();
            }
        }

        #endregion

        #region SelectedIcon : SvgAwesome - Selected icon

        /// <summary>Selected icon</summary>
        private SvgAwesome _SelectedIcon;

        /// <summary>Selected icon</summary>
        public SvgAwesome SelectedIcon
        {
            get => _SelectedIcon;
            set
            {
                Set(ref _SelectedIcon, value);
                SetContent();
            }
        }

        #endregion

        #region IconForeground : SolidColorBrush - Icon color

        /// <summary>Icon color</summary>
        private Color _IconForeground = Colors.WhiteSmoke;

        /// <summary>Icon color</summary>
        public Color IconForeground
        {
            get => _IconForeground;
            set
            {
                Set(ref _IconForeground, value);
                SetContent();
            }
        }

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
                return ImageSource;

            if (!isNone || IconSelectedIndex == 0)
                return null;

            if (IconSelectedIndex == 806)
                return new SvgAwesome()
                {
                    Icon = selected_icon,
                    Height = 25,
                    Foreground = new SolidColorBrush(IconForeground),
                    Spin = true,
                    SpinDuration = 1
                };
            return new SvgAwesome()
            {
                Icon = selected_icon,
                Height = 25,
                Foreground = new SolidColorBrush(IconForeground)
            };
        }

        #endregion

        #region Colors

        #region ContentForeground : SolidColorBrush - Foreground

        /// <summary>Foreground</summary>
        private Color _ContentForeground = Colors.WhiteSmoke;

        /// <summary>Foreground</summary>
        public Color ContentForeground
        {
            get => _ContentForeground;
            set
            {
                Set(ref _ContentForeground, value);
                SetContent();
            }
        }

        #endregion

        #region ContentBackground : SolidColorBrush - Background

        /// <summary>Foreground</summary>
        private Color _ContentBackground = ((SolidColorBrush)new BrushConverter().ConvertFrom("#FF444444")).Color;

        /// <summary>Foreground</summary>
        public Color ContentBackground
        {
            get => _ContentBackground;
            set
            {
                Set(ref _ContentBackground, value);
                SetContent();
            }
        }

        #endregion

        #endregion
        #endregion

        #region Progress

        #region ProgressColor : SolidColorBrush

        /// <summary>Progress line color</summary>
        private Color _ProgressColor = ((SolidColorBrush)new BrushConverter().ConvertFrom("#FF01D328")).Color;

        /// <summary>Progress line color</summary>
        public Color ProgressColor
        {
            get => _ProgressColor;
            set
            {
                Set(ref _ProgressColor, value);
                UpdateProgressArea();
            }
        }

        #endregion

        #region ProgressCollapsed : bool - collapsed progress bar style

        /// <summary>collapsed progress bar style</summary>
        private bool _ProgressCollapsed;

        /// <summary>collapsed progress bar style</summary>
        public bool ProgressCollapsed
        {
            get => _ProgressCollapsed;
            set
            {
                Set(ref _ProgressCollapsed, value);
                UpdateProgressArea();
            }
        }

        #endregion

        #region ProgressTitleOrMessage : bool - Title or message when collapsed

        /// <summary>Title or message when collapsed</summary>
        private bool _ProgressTitleOrMessage;

        /// <summary>Title or message when collapsed</summary>
        public bool ProgressTitleOrMessage
        {
            get => _ProgressTitleOrMessage;
            set
            {
                Set(ref _ProgressTitleOrMessage, value);
                UpdateProgressArea();
            }
        }

        #endregion

        #region ShowCancelButton : bool - show progress cancel btn

        /// <summary>show progress cancel btn</summary>
        private bool _ShowCancelButton = true;

        /// <summary>show progress cancel btn</summary>
        public bool ShowCancelButton
        {
            get => _ShowCancelButton;
            set
            {
                Set(ref _ShowCancelButton, value);
                UpdateProgressArea();
            }
        }

        #endregion

        #region ShowProgress : bool - Show Progress Value

        /// <summary>Show Progress Value</summary>
        private bool _ShowProgress = true;

        /// <summary>Show Progress Value</summary>
        public bool ShowProgress
        {
            get => _ShowProgress;
            set
            {
                Set(ref _ShowProgress, value);
                UpdateProgressArea();
            }
        }

        #endregion

        #region UseWaitingMessage : bool - Use Waiting Message

        /// <summary>Use Waiting Message</summary>
        private bool _UseWaitingMessage = true;

        /// <summary>Use Waiting Message</summary>
        public bool UseWaitingMessage
        {
            get => _UseWaitingMessage;
            set
            {
                Set(ref _UseWaitingMessage, value);
                UpdateProgressArea();
            }
        }

        #endregion
        #region BaseWaitingMessage : string - Base Waiting Message when calculation

        /// <summary>Base Waiting Message when calculation</summary>
        private string _BaseWaitingMessage = "Calculation time";

        /// <summary>Base Waiting Message when calculation</summary>
        public string BaseWaitingMessage
        {
            get => _BaseWaitingMessage;
            set
            {
                Set(ref _BaseWaitingMessage, value);
                UpdateProgressArea();
            }
        }

        #endregion

        #region ProgressValue : double - progress value

        /// <summary>progress value</summary>
        private double _ProgressValue;

        /// <summary>progress value</summary>
        public double ProgressValue
        {
            get => _ProgressValue;
            set
            {
                Set(ref _ProgressValue, value);
                SetProgressValue(value);
            }
        }

        void SetProgressValue(double value)
        {
            if (ProgressNotification?.Content is not NotificationProgress { DataContext: NotificationProgressViewModel context } progress)
                return;
            context.NotifierProgress.Report((ShowProgress ? value : null, MessageSettingModel.Text, TitleSettingModel.Text, ShowCancelButton));
        }

        #endregion

        #endregion

        #region Commands

        #region Open Image command

        public ICommand OpenImageCommand { get; }
        private void OpenImage()
        {
            var openFileDialog = new OpenFileDialog();

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                openFileDialog.Filter = string.Format("{0}{1}{2} ({3})|{3}", openFileDialog.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            openFileDialog.Filter = string.Format("{0}{1}{2} ({3})|{3}", openFileDialog.Filter, sep, "All Files", "*.*");

            openFileDialog.DefaultExt = ".png"; // Default file extension 
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                }
            }
            catch (Exception e)
            {
                _notificationManager.Show("Error", e.Message, type: NotificationType.Error);
            }
        }

        #endregion

        #region Command ICommand : Summary

        /// <summary>Summary</summary>
        public ICommand ShowTestMessageCommand { get; }
        private void TestMessage()
        {
            var clickContent = new NotificationContent
            {
                Title = "Clicked!",
                Message = "Window notification was clicked!",
                Type = NotificationType.Success,
            };

            var content = GetContent(false);

            _notificationManager.Show(content,
                areaName: GetArea(),
                expirationTime: UseExpirationTime ? TimeSpan.FromSeconds(ExpirationTime) : TimeSpan.MaxValue,
                onClick: CloseOnClick ? () =>
                    {
                        _notificationManager.Show(
                            clickContent, ShowXbtn: ShowXBtn, areaName: GetArea(),
                            onClick: () =>
                            {
                                _notificationManager.Show(ImageSource, areaName: GetArea());
                            });
                    }
                    : null,
                ShowXbtn: ShowXBtn);
        }

        #endregion

        #region Command ICommand : Summary

        /// <summary>Summary</summary>
        public ICommand ShowTimerMessageCommand { get; }

        private readonly Timer Timer;

        private void Button_Timer()
        {
            if (!Timer.Enabled) Timer.Start();
            else Timer.Stop();
        }

        #endregion
        #region Command ICommand : Summary

        /// <summary>Summary</summary>
        public ICommand ShowContentCommand { get; }
        private void Show_Any_content()
        {
            var grid = new Grid();
            var text_block = new TextBlock { Text = "Some Text", Margin = new Thickness(0, 10, 0, 0), HorizontalAlignment = HorizontalAlignment.Center };


            var panelBTN = new StackPanel { Height = 100, Margin = new Thickness(0, 40, 0, 0) };
            var btn1 = new Button { Width = 200, Height = 40, Content = "Cancel" };
            var text = new TextBlock
                { Foreground = Brushes.White, Text = "Hello, world", Margin = new Thickness(0, 10, 0, 0), HorizontalAlignment = HorizontalAlignment.Center };
            panelBTN.VerticalAlignment = VerticalAlignment.Bottom;
            panelBTN.Children.Add(btn1);

            //var row1 = new RowDefinition();
            //var row2 = new RowDefinition();
            //var row3 = new RowDefinition();

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());


            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.Children.Add(text_block);
            grid.Children.Add(text);
            grid.Children.Add(panelBTN);

            Grid.SetRow(panelBTN, 1);
            Grid.SetRow(text_block, 0);
            Grid.SetRow(text, 2);

            object content = grid;

            _notificationManager.Show(content, null, TimeSpan.MaxValue);

        }

        #endregion
        #region Command ICommand : Summary

        /// <summary>Summary</summary>
        public ICommand ShowProgressMessageCommand { get; }
        private async void Progress_Click()
        {
            #region First sample

            //using var progress = _notificationManager.ShowProgressBar(
            //    title,
            //    true,
            //    true,
            //    GetArea(),
            //    SelectedTrimType == NotificationTextTrimType.Trim,
            //    2u,
            //    IsCollapse: ProgressCollapsed,
            //    TitleWhenCollapsed: ProgressTitleOrMessage,
            //    progressColor: new SolidColorBrush(ProgressColor),
            //    background: new SolidColorBrush(ContentBackground),
            //    foreground: new SolidColorBrush(ContentForeground), icon: GetIcon(true));

            #endregion

            #region Second sample

            var content = GetContent(true);

            using var progress = _notificationManager.ShowProgressBar(
                content,
                ShowCancelButton,
                ShowProgress,
                GetArea(),
                UseWaitingMessage
                    ? BaseWaitingMessage
                    : "",
                ProgressCollapsed,
                ProgressTitleOrMessage
              , new SolidColorBrush(ProgressColor),ShowXBtn);

            #endregion
            try
            {
                var message = MessageSettingModel.Text;

                await Task.Run(
                    async () =>
                    {
                        for (var i = 0; i <= 100; i++)
                        {
                            progress.Cancel.ThrowIfCancellationRequested();
                            progress.Report((i, message, null, null));
                            progress.WaitingTimer.BaseWaitingMessage = i is > 30 and < 70 ? null : "Calculation time";

                            await Task.Delay(TimeSpan.FromSeconds(0.03), progress.Cancel);
                        }
                    }, progress.Cancel).ConfigureAwait(false);

                for (var i = 0; i <= 100; i++)
                {
                    progress.Cancel.ThrowIfCancellationRequested();
                    progress.Report((i, $"Progress {i}", "With progress", true));
                    await Task.Delay(TimeSpan.FromSeconds(0.02), progress.Cancel).ConfigureAwait(false);
                }

                for (var i = 0; i <= 100; i++)
                {
                    progress.Cancel.ThrowIfCancellationRequested();
                    progress.Report((null, $"{i}", "Whithout progress", null));
                    await Task.Delay(TimeSpan.FromSeconds(0.03), progress.Cancel).ConfigureAwait(false);
                }

                for (var i = 0; i <= 100; i++)
                {
                    progress.Cancel.ThrowIfCancellationRequested();
                    progress.Report((i, null, "Agane whith progress", null));
                    await Task.Delay(TimeSpan.FromSeconds(0.02), progress.Cancel).ConfigureAwait(false);
                }


            }
            catch (OperationCanceledException)
            {
                _notificationManager.Show("Операция отменена", string.Empty, TimeSpan.FromSeconds(3), ShowXbtn: ShowXBtn);
            }
        }

        #endregion


        #endregion

    }
}
