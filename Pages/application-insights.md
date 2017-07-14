# Application Insights

Application Insights is a service for web developers which helps to monitor a live web application. It automatically collects issues and telemetry of the application and sends them to the Microsoft Azure portal where the information can be analyzed.

**DotVVM** supports this service and tracks some additional telemetry which it collects during the processing of a HTTP request.

<img src="{imageDir}application-insights_img1.png" alt="DotVVM metrics in Microsoft Azure portal" />

Show the collected **DotVVM** telemetry by editing any chart in Server request tab. You can choose which metrics you want to show in the metrics tab under Custom drop down menu. You can also choose the desired aggregation.

It is also possible to filter this data by Operation name:

<img src="{imageDir}application-insights_img2.png" alt="Filter metrics in Microsoft Azure portal" />

Finally you can analyze exceptions that were thrown in your web application:

<img src="{imageDir}application-insights_img3.png" alt="Exceptions in Microsoft Azure portal" />

## Getting started

In order to view telemetry data in Microsoft Azure portal you need to create a Microsoft Azure resource. This can be done either through
IDE or manually.

>The process of creating a new Microsoft Azure resource is described in
[Create an Application Insights resource](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-create-new-resource) page.

### ASP.NET Core

You can add Application Insights to an ASP.NET Core project in Visual Studio Solution Explorer or manually.

>Follow this guide: [Application Insights for ASP.NET Core](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-asp-net-core) to add Application Insights in Visual Studio Solution Explorer.

To install Application Insights in your ASP.NET Core project manually you need to add `Microsoft.ApplicationInsights.AspNetCore` NuGet package dependency. Then to view the telemetry data in Microsoft Azure resource you need to add Instrumentation key to `appsettings.json`. You can find this key in the overview of your Microsoft Azure resource. After that you need to add instrumentation code to the `Startup.cs` class in you project and JavaScript instrumentation to the `_ViewImports.cshtml`, `_Layout.cshtml`

>To access more information about the Application Insights configuration in ASP.NET Core project see the
[Getting Started with Application Insights for ASP.NET Core](https://github.com/Microsoft/ApplicationInsights-aspnetcore/wiki/Getting-Started-with-Application-Insights-for-ASP.NET-Core) page.

### Owin

First you need to add Application Insights into your Owin project. You can do this in the Visual Studio Solution Explorer.

>Follow this guide: [Set up Application Insights for your ASP.NET website](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-asp-net) to add Applitaction Insights into your project.

After that install the Application Insights Owin extension into your project. To do that install the package `ApplicationInsights.OwinExtensions`. You also need to modify the `ApplicationInsights.config` and add some additional configuration into the `Startup.cs` class.

>The steps are described in more detail with additional information here: [Application Insights OWIN extensions](https://github.com/marcinbudny/applicationinsights-owinextensions).

## DotVVM telemetry

To collect additional telemetry in **DotVVM** project you need to add `DotVVM.Tracing.ApplicationInsights` NuGet package and then
register its reporter.

### **ASP.NET Core**

In ASP.NET Core it is registered in the method `ConfigureServices` this way:

```CSHARP
services.AddDotVVM(options =>
{
    options.AddApplicationInsightsTracing();
});
```

### Owin

In Owin it is registered in the method `Configuration` this way:

```CSHARP
var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(applicationPhysicalPath, options: options =>
{
    options.AddApplicationInsightsTracing();
});
```

The extension method `AddApplicationInsightsTracing` registers the `TelemetryClient` and an implementation of `IRequestTracingReporter`
which collects information about a HTTP request and its exceptions.
