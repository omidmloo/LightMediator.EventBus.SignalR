---

````markdown
# LightMediator.EventBus.SignalR

[![NuGet](https://img.shields.io/nuget/v/LightMediator.EventBus.SignalR.svg)](https://www.nuget.org/packages/LightMediator.EventBus.SignalR)
[![License](https://img.shields.io/github/license/omidmloo/LightMediator.EventBus.SignalR)](LICENSE)

**LightMediator.EventBus.SignalR** integrates [LightMediator](https://github.com/omidmloo/LightMediator) and [LightMediator.EventBus](https://github.com/omidmloo/LightMediator.EventBus) with **SignalR**, allowing events to be published across applications and domains in real time with minimal configuration.

---

## ✨ Features

- 📡 Broadcasts `IEvent` messages over SignalR with **zero boilerplate**
- 🔁 Seamless integration with `LightMediator.EventBus`
- ⚙️ Configuration-only setup – no custom handlers needed
- 🧩 Pluggable design for multi-layered, distributed applications

---

## 📦 Installation

```bash
dotnet add package LightMediator.EventBus.SignalR
````

--- 

## 🚀 Quick Setup

### 1. Register LightMediator with SignalR support

In `Program.cs`:

No custom handlers are needed. Just configure it in `Program.cs`:

```csharp
services.AddLightMediator(options =>
{
    options.IgnoreNamespaceInAssemblies = true;
    options.IgnoreNotificationDifferences = true;
    options.RegisterNotificationsByAssembly = true;
    options.RegisterRequestsByAssembly = true;

    options.Assemblies = new[]
    {
        Assembly.GetExecutingAssembly(),
        Lib1.GetServiceAssembly(),
        Lib2.GetServiceAssembly(),
        Service1.GetServiceAssembly()
    };

    options.AddLightMediatorEventBus(services)
           .UseSignalRService(
               _configuration.GetSection("LighMediatorSignalRSettings"),
               ignoreUntrustedCertificate: true
           );
});
```

This setup will automatically publish `INotification` implementations across your system using SignalR under the hood.

---


### 2. Add the SignalR Hub endpoint

In your `Startup.cs` or `Program.cs` app configuration:

```csharp
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    // Registers the internal SignalR hub used by LightMediator
    endpoints.ConfigureLightMediatorSignalR();
});
```

---

## 🔧 Configuration

Add this to your `appsettings.json`:

```json
"LighMediatorSignalRSettings": {
    "ServerAddress": "https://localhost:5000/",
    "AccessToken": "your-auth-token",
}
```

> 🔐 `AccessToken` is optional depending on your SignalR configuration.

---

## 🧱 Dependencies

This package depends on:

* [LightMediator](https://github.com/omidmloo/LightMediator)
* [LightMediator.EventBus](https://github.com/omidmloo/LightMediator.EventBus)
* `Microsoft.AspNetCore.SignalR.Client`

---

## 📝 License

Licensed under the [MIT License](LICENSE).

---

## 💬 Contact

For issues or contributions, visit the [GitHub repo](https://github.com/omidmloo/LightMediator.EventBus.SignalR) or contact [@omidmloo](https://github.com/omidmloo).

