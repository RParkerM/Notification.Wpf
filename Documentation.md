<details>	
  <br />
  <summary><h2>🔰 Initialization</h3></summary>
    
- ### 1 method
    
Regster as services
    
```
   services.AddSingleton<INotificationManager, NotificationManager>(); 
```

<details>	
  <br />
  <summary><b>👩‍💻 Full code</b></summary>
    
```csharp=
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
public sealed partial class App
{
    public static IServiceProvider Services => Hosting.Services;
    private static IHost __Hosting;

    public static IHost Hosting => __Hosting ??=
        CreateHostBuilder(Environment.GetCommandLineArgs())
           .Build();

    public static IHostBuilder CreateHostBuilder(string[] args) => Host
       .CreateDefaultBuilder(args)
       .ConfigureServices(ConfigureServices);

    private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
    {
        //...
        services.AddSingleton<INotificationManager, NotificationManager>();
        //...
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        var host = Hosting;
        base.OnStartup(e);
        await host.StartAsync();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
        using var host = Hosting;
        await host.StopAsync();
    }
}
``` 
    
</details>   
    
- ### 2 method
  override with you static class  
```csharp
public static class Notifier
{
    private static readonly NotificationManager __NotificationManager = new();
    static Notifier() => Resources.Culture = Thread.CurrentThread.CurrentUICulture;


public static void Show(...)
{
    ...

    __NotificationManager.Show(...);
}
``` 

</details>
    
<details>	
  <br />
  <summary><h2>🔔 Notifications</h2></summary>

```csharp
    var content = new NotificationContent();
    notificationManager.Show(content);
    notificationManager.Show("Title","Message");
```
[Message initialization methods](https://github.com/Platonenkov/Notification.Wpf/blob/dev/Notification.Wpf/Base/Interfaces/Base/IMessageManager.cs)
</details>
    
<details>	
  <br />
  <summary><h2>💤 Progress bar</h2></summary>

```csharp
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
  
<details>	
  <br />
  <summary><h2>🔥 Properties</h2></summary>
    
At this moment enabled:
    
<details>	
  <br />
  <summary><b>1.     text properties</b></summary>   
    
- For Notification content
    
```csharp
public TextContentSettings TextSettings = new()
{
    FontStyle = FontStyles.Normal,
    FontFamily = new FontFamily("Segoe UI"),
    FontSize = 16,
    FontWeight = FontWeights.Bold,
    TextAlignment = TextAlignment.Center,
    HorizontalAlignment = HorizontalAlignment.Stretch,
    VerticalTextAlignment = VerticalAlignment.Stretch,
    Opacity = 1
};
```
- For all messages
    
```csharp=
    NotificationConstants.FontName = "Segoe UI";
    
    NotificationConstants.MessageSize = 14;
    NotificationConstants.TitleSize = 14;
    
    NotificationConstants.MessageTextAlignment = TextAlignment.Left;
    NotificationConstants.TitleTextAlignment = TextAlignment.Left;
```
    
</details>
<details>	
  <br />
  <summary><b>2.     Default text</b></summary>   

```csharp=
    NotificationConstants.CancellationMessage = "Operation was cancelled";
    NotificationConstants.DefaultProgressButtonContent = "Cancel"; //object content
    
    NotificationConstants.OpenFileMessage = "Open File";
    NotificationConstants.OpenFolderMessage = "Open Folder";

    
    NotificationConstants.DefaultLeftButtonContent = "Ok"; //object content
    NotificationConstants.DefaultRightButtonContent = "Cancel"; //object content
```
    
</details>    
  
<details>	
  <br />
  <summary><b>3.     Text trim and row count</b></summary>   

```csharp=
    //message maximum count
    NotificationConstants.DefaultRowCounts = 2U;
    NotificationConstants.DefaulTextTrimType = NotificationTextTrimType.NoTrim;
    
```
    
</details>   
  
<details>	
  <br />
  <summary><b>4.     Colors</b></summary>   

```csharp=
NotificationConstants.SuccessBackgroundColor = new SolidColorBrush(Colors.LimeGreen);
NotificationConstants.WarningBackgroundColor = new SolidColorBrush(Colors.Orange);
NotificationConstants.ErrorBackgroundColor = new SolidColorBrush(Colors.OrangeRed);
NotificationConstants.InformationBackgroundColor = new SolidColorBrush(Colors.CornflowerBlue);
NotificationConstants.DefaultBackgroundColor = (Brush)new NotificationConstants.BrushConverter().ConvertFrom("#FF444444");
NotificationConstants.DefaultForegroundColor = new SolidColorBrush(Colors.WhiteSmoke);
NotificationConstants.DefaultProgressColor = (Brush)new BrushConverter().ConvertFrom("#FF01D328");
```
    
</details>  
    
<details>	
  <br />
  <summary><b>5.     Message position and Maximum count</b></summary>     
    
- Inside you window:
```xml=
<notifications:NotificationArea x:Name="WindowArea" Position="TopLeft" MaxItems="3"/>
```
- For task bar messages
Will work when will start new message stack.
    
```csharp=
    NotificationConstants.MessagePosition = NotificationPosition.BottomRight;
    
    //If messages count in overlay window will be more that maximum - progress bar will start collapsed (progress bar never closing automatically)
    NotificationConstants.CollapseProgressIfMoreRows = true;
``` 

- For `Absolute` message position:
Set Message position as `Absolute`, and set `NotificationConstants.AbsolutePosition`

but, You must set base corner for position margin.

Sample:
```
NotificationConstants.AbsolutePosition.X = 50D;
NotificationConstants.AbsolutePosition.Y = 100D;
NotificationConstants.AbsolutePosition.BaseCorner= Corner.TopRight;
```

- Reverse message stack
Decide what message will be from above
Use `NotificationConstants.IsReversedPanel` to change stack orientation. Set as `null to default`.


</details>   
<details>	
  <br />
  <summary><b>6.     Size</b></summary>     
    
```csharp=
    NotificationConstants.MinWidth = 350D;
    NotificationConstants.MaxWidth = 350D;
``` 

![](https://via.placeholder.com/30x15/f03c15/000000?text=+) `if MaxWidth less than MinWidth:`
  
![](https://via.placeholder.com/30x15/f03c15/000000?text=+) `MinWidth = MaxWidth`
    
</details> 
</details>
