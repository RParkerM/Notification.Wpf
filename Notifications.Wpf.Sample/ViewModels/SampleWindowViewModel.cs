using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using MathCore.ViewModels;
using Notification.Wpf.Controls;

namespace Notification.Wpf.Sample.ViewModels
{
    public class SampleWindowViewModel : ViewModel
    {
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
        public double AreaMinWidth { get => _AreaMinWidth; set => Set(ref _AreaMinWidth, value); }

        #endregion

        #region AreaMaxWidth : double - Max width

        /// <summary>Max width</summary>
        private double _AreaMaxWidth = 350D;

        /// <summary>Max width</summary>
        public double AreaMaxWidth { get => _AreaMaxWidth; set => Set(ref _AreaMaxWidth, value); }

        #endregion

        #endregion

        #region Window Settings

        #region CollapseProgressIfMoreRows : bool - progress bar automatical collapsing , if messages count more than maximum

        /// <summary>progress bar automatical collapsing , if messages count more than maximum</summary>
        private bool _CollapseProgressIfMoreRows;

        /// <summary>progress bar automatical collapsing , if messages count more than maximum</summary>
        public bool CollapseProgressIfMoreRows { get => _CollapseProgressIfMoreRows; set => Set(ref _CollapseProgressIfMoreRows, value); }

        #endregion
        #region MaxItems : int - Max message stack

        /// <summary>Max message stack</summary>
        private int _MaxItems = 5;

        /// <summary>Max message stack</summary>
        public int MaxItems { get => _MaxItems; set => Set(ref _MaxItems, value); }

        #endregion

        #region MessagePosition : NotificationPosition - Message position

        /// <summary>Message position</summary>
        private NotificationPosition _MessagePosition = NotificationPosition.BottomRight;

        /// <summary>Message position</summary>
        public NotificationPosition MessagePosition { get => _MessagePosition; set => Set(ref _MessagePosition, value); }

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


        #endregion
    }
}
