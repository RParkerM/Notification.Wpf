using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

using Notification.Wpf.Base.Interfaces.Options;
using Notification.Wpf.Classes;
using Notification.Wpf.Constants;

using Notifications.Wpf.Annotations;

namespace Notification.Wpf.Base.Interfaces.Base
{
    /// <summary> Message manager </summary>
    public interface IMessageManager
    {
        /// <summary> Show any content </summary>
        /// <param name="content">window content</param>
        /// <param name="areaName">window are where show notification</param>
        /// <param name="expirationTime">time after which the window will disappear</param>
        /// <param name="onClick">what should happen when clicking on the window</param>
        /// <param name="onClose">what should happen when window closing</param>
        /// <param name="CloseOnClick">close window after clicking</param>
        /// <param name="ShowXbtn">Show X (close) btn</param>
        void Show(
            object content,
            string areaName = "",
            TimeSpan? expirationTime = null,
            Action onClick = null, Action onClose = null,
            bool CloseOnClick = true,
            bool ShowXbtn = true);

        /// <summary> Show message </summary>
        /// <param name="title">window title</param>
        /// <param name="message">Message in window</param>
        /// <param name="type">Window type</param>
        /// <param name="areaName">window are where show notification</param>
        /// <param name="expirationTime">time after which the window will disappear</param>
        /// <param name="onClick">what should happen when clicking on the window</param>
        /// <param name="onClose">what should happen when window closing</param>
        /// <param name="LeftButton">what should happen when clicking on the left button (if null - button not visible)</param>
        /// <param name="LeftButtonText">what should be written on the left button</param>
        /// <param name="RightButton">what should happen when clicking on the right button (if null - button not visible)</param>
        /// <param name="RightButtonText">what should be written on the right button</param>
        /// <param name="trim">trim text if it is longer than the number of visible lines</param>
        /// <param name="RowsCountWhenTrim">Base number of rows when trims</param>
        /// <param name="CloseOnClick">close window after clicking</param>
        /// <param name="TitleSettings">Настройки отображения Title</param>
        /// <param name="MessageSettings">Настройки отображения сообщения</param>
        /// <param name="ShowXbtn">Show X (close) btn</param>
        /// <param name="icon">Message icon</param>
        void Show(
            string title, string message, NotificationType type = NotificationType.None,
            string areaName = "",
            TimeSpan? expirationTime = null,
            Action onClick = null, Action onClose = null,
            Action LeftButton = null, string LeftButtonText = null,
            Action RightButton = null, string RightButtonText = null,
            NotificationTextTrimType trim = NotificationTextTrimType.NoTrim, uint RowsCountWhenTrim = 2,
            bool CloseOnClick = true,
            TextContentSettings TitleSettings = null, TextContentSettings MessageSettings = null,
            bool ShowXbtn = true,
            object icon = null
        );
        /// <summary> Show no titled message  </summary>
        /// <param name="message">Message in window</param>
        /// <param name="type">Window type</param>
        /// <param name="areaName">window are where show notification</param>
        /// <param name="expirationTime">time after which the window will disappear</param>
        /// <param name="trim">trim text if it is longer than the number of visible lines</param>
        /// <param name="RowsCountWhenTrim">Base number of rows when trims</param>
        /// <param name="CloseOnClick">close window after clicking</param>
        /// <param name="MessageSettings">Настройки отображения сообщения</param>
        /// <param name="ShowXbtn">Show X (close) btn</param>
        /// <param name="icon">Message icon</param>
        void Show(
            string message, NotificationType type = NotificationType.None, string areaName = "",
            TimeSpan? expirationTime = null,
            NotificationTextTrimType trim = NotificationTextTrimType.NoTrim,
            uint RowsCountWhenTrim = 1,
            bool CloseOnClick = true,
            TextContentSettings MessageSettings = null,
            bool ShowXbtn = true,
            object icon = null
        );

        /// <summary> Show error message </summary>
        /// <param name="e">error</param>
        /// <param name="areaName">window are where show notification</param>
        /// <param name="expirationTime">time after which the window will disappear</param>
        /// <param name="RowsCountWhenTrim">Base number of rows when trims</param>
        /// <param name="MessageSettings">Настройки отображения сообщения</param>
        /// <param name="ShowXbtn">Show X (close) btn</param>
        void Show(
            [NotNull] Exception e,
            string areaName = "",
            TimeSpan? expirationTime = null, uint RowsCountWhenTrim = 5,
            TextContentSettings MessageSettings = null,
            bool ShowXbtn = true) =>
            Show(
                $"{e.Message}\n\r{e}",
                NotificationType.Error,
                areaName,
                expirationTime ?? TimeSpan.MaxValue,
                NotificationTextTrimType.AttachIfMoreRows,
                RowsCountWhenTrim, true, MessageSettings, ShowXbtn);

        /// <summary> Show Cancellation message</summary>
        void ShowCancellation(NotificationType type = NotificationType.Warning, string areaName = "",
            TextContentSettings MessageSettings = null,
            bool ShowXbtn = true) => Show(NotificationConstants.CancellationMessage, NotificationType.Warning, MessageSettings: MessageSettings, ShowXbtn: ShowXbtn);


        /// <summary>
        /// Show message with button to open file or directory (file destination)
        /// Показывает всплывающее окно для открытия файла или директории
        /// </summary>
        /// <param name="FilePath">File path</param>
        /// <param name="ShowFile">show file button</param>
        /// <param name="ShowDirectory">show directory button</param>
        /// <param name="options">customization options</param>
        /// <param name="image">image if need</param>
        /// <param name="ExpirationTime">time after which the window will disappear </param>
        /// <param name="AreaName">window area</param>
        public void ShowFilePopUpMessage(string FilePath, bool ShowFile = true, bool ShowDirectory = true,
            TimeSpan? ExpirationTime = null, string AreaName = "",
            ICustomizedOptions options = null,
            NotificationImage image = null) =>
            ShowButtonWindow($"{NotificationConstants.OpenFileMessage}?", null,
                ShowFile ? (_, _) =>
                    {
                        try
                        {
                            new Process { StartInfo = new ProcessStartInfo(FilePath) { UseShellExecute = true } }.Start();
                        }
                        catch (Exception exc)
                        {
                            Show(exc);
                        }
                    }
        : null
              , ShowFile ? NotificationConstants.OpenFileMessage : null,
                ShowDirectory ? (_, _) =>
                    {
                        try
                        {
                            new Process { StartInfo = new ProcessStartInfo(Path.GetDirectoryName(FilePath) ?? throw new ArgumentNullException(nameof(FilePath), "File path can\t be null")) { UseShellExecute = true } }.Start();
                        }
                        catch (Exception exc)
                        {
                            Show(exc);
                        }

                    }
        : null, ShowDirectory ? NotificationConstants.OpenFolderMessage : null, ExpirationTime, AreaName, options, image);

        /// <summary>
        /// Show message with buttons
        /// </summary>
        /// <param name="Message">Message</param>
        /// <param name="Title">Title</param>
        /// <param name="LeftButton">Left button action (if null - not visible)</param>
        /// <param name="LeftButtonContent">Left button content (possible text) - if null - "Cancel"</param>
        /// <param name="RightButton">Right button action (if null - not visible)</param>
        /// <param name="RightButtonContent">Right button content (possible text) - if null - "Ok"</param>
        /// <param name="ExpirationTime">time after which the window will disappear</param>
        /// <param name="AreaName">area name</param>
        /// <param name="Image">image</param>
        /// <param name="options"> Customization options </param>
        /// <example>
        /// <code>
        /// Notifier.ShowInfoWindow("The picture is successfully added","Success",
        /// RightButton:(Sender, Args) =&gt; _ = Process.Start(report_file.FullName), RightButtonContent:"Open file",
        /// TimeSpan:TimeSpan.FromSeconds(10));
        /// </code>
        /// </example>
        void ShowButtonWindow(string Message, [CanBeNull] string Title = null,
        [CanBeNull] RoutedEventHandler LeftButton = null, string LeftButtonContent = null,
            [CanBeNull] RoutedEventHandler RightButton = null, string RightButtonContent = null,
            TimeSpan? ExpirationTime = null, string AreaName = "", ICustomizedOptions options = null, NotificationImage Image = null)
        {
            NotificationContent content = options is not null
                ? new NotificationContent()
                {
                    Title = Title,
                    Message = Message,
                    Type = NotificationType.Notification,
                    LeftButtonAction = LeftButton is null
                        ? null
                        : () => LeftButton.Invoke(null, null),
                    LeftButtonContent = LeftButtonContent,
                    RightButtonAction = RightButton is null
                        ? null
                        : () => RightButton.Invoke(null, null),
                    RightButtonContent = RightButtonContent,
                    Image = Image,
                    Background = options.Background,
                    Foreground = options.Foreground,
                    Icon = options.Icon,
                    MessageTextSettings = options.MessageTextSettings,
                    TitleTextSettings = options.TitleTextSettings,
                    RowsCount = options.RowsCount,
                    TrimType = options.TrimType
                }
                : new NotificationContent()
                {
                    Title = Title,
                    Message = Message,
                    Type = NotificationType.Notification,
                    LeftButtonAction = LeftButton is null
                        ? null
                        : () => LeftButton.Invoke(null, null),
                    LeftButtonContent = LeftButtonContent,
                    RightButtonAction = RightButton is null
                        ? null
                        : () => RightButton.Invoke(null, null),
                    RightButtonContent = RightButtonContent,
                    Image = Image
                };

            Show(content, AreaName, ExpirationTime, null, null, false);
        }
    }

}
