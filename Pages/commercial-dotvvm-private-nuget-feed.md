## DotVVM Private Nuget Feed

The commerical version of [DotVVM for Visual Studio 2015](/landing/dotvvm-for-visual-studio-extension) adds *DotVVM Private Nuget Feed* in the Visual Studio.

This feed is authenticated and requires you to sign in using the same credentials you use on this website.
The [Bootstrap for DotVVM](/landing/bootstrap-for-dotvvm) controls are distributed using this feed, and you can also find pre-release versions of DotVVM Core in this feed.


### Adding the Feed

The installer of the DotVVM extension should add this Nuget feed automatically, but if you only bought [Bootstrap for DotVVM](/landing/bootstrap-for-dotvvm), you'll have to
add the feed yourself.

1. Choose the _Tools > Options_ menu item in the Visual Studio.

2. Navigate to the _Nuget Package Manager > Package Sources_ and add the following feed there:

```
https://www.dotvvm.com/nuget/v3/index.json
```

3. Don't forget to click the _Update_ button.

4. Confirm the changes.

When you first use the feed, it should ask for your credentials. Use the same credentials as you used on this website when you purchased the license. 
The feed will display only the packages for which you own a license.