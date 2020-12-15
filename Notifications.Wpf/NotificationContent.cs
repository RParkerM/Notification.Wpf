﻿namespace Notification.Wpf
{
    public class NotificationContent
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public NotificationType Type { get; set; }
        public NotificationTextTrimType TrimType { get; set; } = NotificationTextTrimType.NoTrim;
        public uint RowsCount { get; set; } = 2;
    }

    /// <summary>
    /// Способ отображения текста в сообщении
    /// </summary>
    public enum NotificationTextTrimType
    {
        NoTrim,
        Trim,
        Attach,
        AttachIfMoreRows
    }
    /// <summary>
    /// Тип сообщения
    /// </summary>
    public enum NotificationType   
    {
        Information,
        Success,
        Warning,
        Error,
        Notification,
        AttachText
    }
}
