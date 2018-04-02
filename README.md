# Introduction
Thomas Makin's HTHS Sophomore Research Project. Using network ping and three stationary routers, one's approximate location can be determined.
This Windows Presentation Foundation Win32 app will at launch display the approximate location of the computer running the application by measuring the
round-trip ping time, halving it, repeating the previous two steps nine more times, converting the average time (ms) to approximate meters, and creating a
circle with a radius of that value around the specified router on a map. That process will be repeated for the remaining two routers in addition.

# Getting Started
1.	Installation: Connect to the Git server on Visual Studio 2017. If required, request permission.
2.  Dependencies: N/A
3.	Latest releases: N/A
4.	References: Microsoft.CSharp, PresentationCore, PresentationFramework, System (.Core, .Data, .Data,DataSetExtensions, .Net.Http, .Xaml, .Xml, .Xml.Linq),
WindowsBase

# Build and Test
No tests required at this point. To build project, just run the code in Visual Studio on Debug or Release on AnyCPU.

# Contribute
I would like to have this working with the built-in example by the end of the year, and the program itself will follow with no required timeframe.
Read the comments on MainPage.xaml.cs and the run the project--everything makes sense then.