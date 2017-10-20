@echo off

%~d0
cd "%~p0"

del *.nu*
del *.dll
del *.xml
del *.cs

copy ..\ReactLoader.cs > nul

copy ..\Bridge.ReactLoader.Debug\bin\Release\Bridge.ReactLoader.Debug.dll > nul
copy ..\Bridge.ReactLoader.Debug\bin\Release\Bridge.ReactLoader.Debug.xml > nul

copy ..\Bridge.ReactLoader.Release\bin\Release\Bridge.ReactLoader.Release.dll > nul
copy ..\Bridge.ReactLoader.Release\bin\Release\Bridge.ReactLoader.Release.xml > nul

copy ..\Bridge.ReactLoader.nuspec > nul
nuget pack -NoPackageAnalysis Bridge.ReactLoader.nuspec