## MiniProfiler

> This feature is available in DotVVM 1.1.5 and higher.

[MiniProfiler](http://miniprofiler.com/dotnet/) is a library and UI for profiling your application. By letting you see where your time is spent, which queries are run, 
and any other custom timings you want to add. It helps you debug issues and optimize performance.

> MiniProfiler was designed by the team at [Stack Overflow](https://stackoverflow.com/) and is extensively used in production by their team.

**DotVVM** supports this library and tracks some additional metrics which it collects during the processing of an HTTP request.

You can display the collected **DotVVM** metrics by adding the MiniProfiler Widget to a dothtml page:

<img src="miniprofiler-widget.png" alt="DotVVM metrics in MiniProfiler" class="img-responsive" /> 

It is also possible to view the data traced in previous HTTP requests:

<img src="miniprofiler-page.png" alt="List of traced HTTP requests with details" class="img-responsive" />

> MiniProfiler is capable of profiling other 3rd party services, e.g. Entity Framework and Redis.

### Getting Started

MiniProfiler installation and configuration differs for [ASP.NET Core](#AspNetCore) and [OWIN](#Owin). You can find the details for extended configuration 
in the [MiniProfiler documentation](http://miniprofiler.com/dotnet/).

For both ASP.NET Core and OWIN, you can use the `MiniProfilerWidget`, which is a DotVVM control with many options like `MaxTraces`, `Position`, `StartHidden` etc.:

```DOTHTML
    <dot:MiniProfilerWidget Position="Right" ShowTrivial="true" StartHidden="true" />
```

<br />

#### <a name="AspNetCore"></a>ASP.NET Core

> Be aware that MiniProfiler for ASP.NET Core is currently in alpha pre-release version.

1. Run the following commands in the _Package Manager Console_ window:

```
Install-Package MiniProfiler.AspNetCore -IncludePrerelease
Install-Package DotVVM.Tracing.MiniProfiler.AspNetCore
```

2. Next, you can register the MiniProfiler integration into DotVVM request tracing in the `ConfigureServices` method this way:

```CSHARP
services.AddDotVVM(options =>
{
    options.AddMiniProfilerEventTracing();
});
```

3. As the last step, you need to add the MiniProfiler middleware before `app.UseDotVVM<DotvvmStartup>()`:

```CSHARP
app.UseMiniProfiler(new MiniProfilerOptions
{
    // Path to use for profiler URLs
    RouteBasePath = "~/profiler",

    // (Optional) Control storage
    Storage = new MemoryCacheStorage(cache, TimeSpan.FromMinutes(60)),
});
```

* To see it in action, you can simply navigate to `~/profiler/results-index` and view profiled HTTP requests.

> To see more information about the MiniProfiler configuration in ASP.NET Core project see the
[MiniProfiler for ASP.NET Core Documentation](http://miniprofiler.com/dotnet/AspDotNetCore) page.

> We have a [sample application](https://github.com/riganti/dotvvm/tree/master/src/DotVVM.Samples.MiniProfiler.AspNetCore) to show how MiniProfiler can be used with ASP.NET Core.

<br />

#### <a name="Owin"></a>Getting Started on OWIN

1. Either use the NuGet UI to install `MiniProfiler` and `DotVVM.Tracing.MiniProfiler.Owin`, or use the following commands in the _Package Manager Console_ window:

```
Install-Package MiniProfiler
Install-Package DotVVM.Tracing.MiniProfiler.Owin
```

2. Register the DotVVM request tracing in the `ConfigureServices` method this way:

```CSHARP
var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(applicationPhysicalPath, options: options =>
{
    options.AddMiniProfilerEventTracing();
});
```

* To see it in action, you can simply navigate to `~/mini-profiler-resources/results-index` and view profiled HTTP requests.

You can change MiniProfiler default setting as you would do without DotVVM integration, for example:

```CSHARP
StackExchange.Profiling.MiniProfiler.Settings.RouteBasePath = "~/profiler";
```
            
