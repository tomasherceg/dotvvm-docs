## Installing Bootstrap for DotVVM

To use the [Bootstrap for DotVVM](/landing/bootstrap-for-dotvvm) controls, you have use the [DotVVM Private Nuget Feed](/docs/tutorials/commercial-dotvvm-private-nuget-feed).

1. Install the package from the DotVVM Private Nuget Feed.

2. Open your `DotvvmStartup.cs` file and add the following line at the beginning of the `Configure` method.

```CSHARP
config.AddBootstrapConfiguration();
``` 

You might need to add the following `using` at the beginning of the file.

```CSHARP
using DotVVM.Framework.Controls.Bootstrap;
```

This will register all Bootstrap controls under the `<bs:*` tag prefix, and it also registers several Bootstrap resources. 

<br />

### Configuration

The [Bootstrap for DotVVM](/landing/bootstrap-for-dotvvm) package doesn't include the bootstrap CSS and javascript libraries as they are too large and you might have your own compilation of Bootstrap (e.g. if you use some Bootstrap template).   

You have the following options:

**Option 1**: If you don't have Bootstrap installed in your project, install the `Bootstrap` package from the official Nuget feed.

```
Install-Package Bootstrap
```

**Option 2**:  If you already use Bootstrap in your project, make sure the JS and CSS files of Bootstrap are on the following paths:

* `/Content/bootstrap.min.css`
* `/Scripts/bootstrap.min.js`

**Option 3**:  If you have these files elsewhere, you can change the URLs where DotVVM looks for these files in the `DotvvmStartup.cs` file:

```CSHARP
config.Resources.FindResource("bootstrap").Url = "your bootstrap.min.js URL";   // the URL should start with ~/
config.Resources.FindResource("bootstrap-css").Url = "your bootstrap.min.css URL";   // the URL should start with ~/
```

**Option 4**:  If you have already included the bootstrap script and styles using the `<script>` and `<style>` elements in the page header (e.g. in the master page), you can tell DotVVM that it should not render the default bootstrap resources. Add this in the master page:

```CSHARP
resources.Register("jquery", new NullResource());
resources.Register("bootstrap", new NullResource());
resources.Register("bootstrap-css", new NullResource());
```

In the last method, DotVVM will assume that you have already loaded these resources yourself and it won't care about them. If any control requires them, DotVVM won't render the script and style elements because the resource has already been included in the page.

<br />

### Limitations

The current version of [Bootstrap for DotVVM](/landing/bootstrap-for-dotvvm) supports **Bootstrap 3**. For more information about Bootstrap, navigate into its [documentation](https://getbootstrap.com).
