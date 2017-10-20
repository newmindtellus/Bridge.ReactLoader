# Bridge.ReactLoader
A NuGet package to load the React library into a Bridge application (Dev/Production library version depending upon Debug/Release project configuration).

The [Bridge.React](https://github.com/ProductiveRage/Bridge.React) bindings ([NuGet](https://www.nuget.org/packages/Bridge.React)) provide Bridge bindings to the React library but that package does not load the React library itself, it leaves that responsibility to the application that uses the Bridge.React package. Previously, the simplest way to load the React library has been to emit additional script tags in the html that renders the application but that has some problems - amongst which is the fact that it is a manual step to change from using the "Dev" version of the library (while developing the application) to using the "Production" version (for when the application is published).

This NuGet package will include the React library scripts directly to your project - adding the Dev version when the project is built using the Debug configuration and adding the Production version otherwise.

### An example

To see this working, starting from a blank slate, do the following:

1. Create a new solution that contains a single C# Class Library project called "ReactExample"
1. Add the NuGet package "Bridge" (this configures the project to emit JavaScript and a html "scaffolding" page, using a default "bridge.json" configuration file that is added to the project)
1. Add the NuGet package "Bridge.ReactLoader" (note that this will add a file "ReactLoader.cs" to your project - this is necessary for the package to work and to load the Dev / Production build appropriate for your project's configuration, so don't edit the file manually or delete it)
1. Add the NuGet package "Bride.React" (which provides C# bindings to the React library)
1. Edit the "Class1.cs" file that was created as part of the initial Class Library project so that it has the content below
1. Build the project and go to the output folder (the default bridge.json configuration will write files to "bin/Debug/bridge" or "bin/Release/bridge") where you will see an auto-generated index.html; if you open this in the browser then you will see the "This was rendered by React!" message


```
using Bridge.Html5;
using Bridge.React;

namespace ReactExample
{
    public class Class1
    {
        public static void Main()
        {
            var container = Document.CreateElement("div");
            Document.Body.AppendChild(container);
            React.Render(
                DOM.Div("This was rendered by React!"),
                container
            );
        }
    }
}
```

If you view the source of the html file then you will see that the library files have been automatically added as script tags in the html. If you built your project in Debug configuration then the Dev version of the library will have been included, otherwise the Production version will be.

Note: The above example uses the default bridge.json configuration options, which include all of the scripts from referenced assemblies as individual script tags. If you want to use the [combineScripts: true](https://github.com/bridgedotnet/Bridge/wiki/global-configuration#combinescripts) option that Bridge supports then that will work as well. In this case, the React library content will be bundled into the single JavaScript output file (only the Dev _or_ Production library will be included - it will not include both versions, just as the approach shown above includes scripts tag for _either_ the Dev version of the library _or_ the Production version).

### Versioning

The version of the NuGet package will be related to the version of the React library that is included, the first two values will relate to the React library version whils the last value will relate to version of this library - for example, "16.0.1" is build 1 of the NuGet package that loads React 16.0.