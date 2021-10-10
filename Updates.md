### How to:
first - create `INotificationManager notificationManager = new NotificationManager();`
<details>	
  <br />
  <summary><b>🔥 Create new Notification</b></summary>

```C#
    var content = new NotificationContent();
    notificationManager.Show(content);
    notificationManager.Show("Title","Message");
```
[Message initialization methods](https://github.com/Platonenkov/Notification.Wpf/blob/dev/Notification.Wpf/Base/Interfaces/Base/IMessageManager.cs)
</details>

<details>	
  <br />
  <summary><b>🔥 Create new Progress rar</b></summary>

```C#
using var progress = notificationManager.ShowProgressBar();
for (var i = 0; i <= 100; i++)
{
    progress.Cancel.ThrowIfCancellationRequested();
    progress.Report((i, $"Progress {i}", "With progress", true));
    await Task.Delay(TimeSpan.FromSeconds(0.02), progress.Cancel).ConfigureAwait(false);
}
```
[Progress initialization methods](https://github.com/Platonenkov/Notification.Wpf/blob/dev/Notification.Wpf/Base/Interfaces/Base/IProgressManager.cs)
</details>
  
  
### Update list

`v5.6.1`
* Added Image template for Notification content
  
`v5.6.0`
* Added overlay window position from constants,
* ImageSource template for icon,
* X-Close button visible setting
* Add Notification Min and Max Setting

`v5.5.0`
* Added text style settings to content

`v5.4.0`
* Added section for image
* if icon is null - left column will collapse

`v5.3.0`
* access to basic message settings
* setting the number of messages in the window
* settings for the progress bar  to automatically collapse with a large number of messages
* settings progress bar styles
* New progress bar initializing template
* Add more sample in test project

[Constants](https://github.com/Platonenkov/Notification.Wpf/blob/dev/Notification.Wpf/Constants/NotificationConstants.cs)

Just change it befor first using

`v5.2.0`
* Color and Icons in settings

`v5.1.0`
* Add Slowed progress bar
* Add Waiting timer for progress bar

`v5.0.0`
* Platform support
