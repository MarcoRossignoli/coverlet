# Run Test

1) Clone this branch
2) Run pack
```
C:\git\coverlet (testdet -> origin)
λ dotnet pack
Microsoft (R) Build Engine version 16.5.0+d4cbfca49 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 84,02 ms for C:\git\coverlet\test\coverlet.tests.projectsample.excludedbyattribute\coverlet.tests.projectsample.excludedbyattribute.csproj.
  Restore completed in 82,88 ms for C:\git\coverlet\src\coverlet.console\coverlet.console.csproj.
  Restore completed in 82,84 ms for C:\git\coverlet\src\coverlet.collector\coverlet.collector.csproj.
  Restore completed in 82,79 ms for C:\git\coverlet\test\coverlet.tests.projectsample.empty\coverlet.tests.projectsample.empty.csproj.
  Restore completed in 83,32 ms for C:\git\coverlet\test\coverlet.tests.xunit.extensions\coverlet.tests.xunit.extensions.csproj.
  Restore completed in 82,84 ms for C:\git\coverlet\test\coverlet.core.tests.samples.netstandard\coverlet.core.tests.samples.netstandard.csproj.
  Restore completed in 86,67 ms for C:\git\coverlet\test\coverlet.core.performancetest\coverlet.core.performancetest.csproj.
  Restore completed in 86,59 ms for C:\git\coverlet\test\coverlet.integration.tests\coverlet.integration.tests.csproj.
  Restore completed in 83,57 ms for C:\git\coverlet\src\coverlet.msbuild.tasks\coverlet.msbuild.tasks.csproj.
  Restore completed in 83,72 ms for C:\git\coverlet\test\coverlet.testsubject\coverlet.testsubject.csproj.
  Restore completed in 82,9 ms for C:\git\coverlet\src\coverlet.core\coverlet.core.csproj.
  Restore completed in 87,28 ms for C:\git\coverlet\test\coverlet.collector.tests\coverlet.collector.tests.csproj.
  Restore completed in 87,59 ms for C:\git\coverlet\test\coverlet.integration.template\coverlet.integration.template.csproj.
  Restore completed in 124,79 ms for C:\git\coverlet\test\coverlet.core.tests\coverlet.core.tests.csproj.
  coverlet.core -> C:\git\coverlet\src\coverlet.core\bin\Debug\netstandard2.0\coverlet.core.dll
  coverlet.collector -> C:\git\coverlet\src\coverlet.collector\bin\Debug\netcoreapp2.0\coverlet.collector.dll
  coverlet.console -> C:\git\coverlet\src\coverlet.console\bin\Debug\netcoreapp2.2\coverlet.console.dll
  coverlet.console -> C:\git\coverlet\src\coverlet.console\bin\Debug\netcoreapp2.2\coverlet.console.dll
  Successfully created package 'C:\git\coverlet\bin\Debug\Packages\coverlet.collector.1.3.0-preview.7.g18a53d00b8.nupkg'.
  Successfully created package 'C:\git\coverlet\bin\Debug\Packages\coverlet.collector.1.3.0-preview.7.g18a53d00b8.snupkg'.
  coverlet.msbuild.tasks -> C:\git\coverlet\src\coverlet.msbuild.tasks\bin\Debug\netstandard2.0\coverlet.msbuild.tasks.dll
  Successfully created package 'C:\git\coverlet\bin\Debug\Packages\coverlet.console.1.7.2-preview.7.g18a53d00b8.nupkg'.
  Successfully created package 'C:\git\coverlet\bin\Debug\Packages\coverlet.console.1.7.2-preview.7.g18a53d00b8.snupkg'.
  Successfully created package 'C:\git\coverlet\bin\Debug\Packages\coverlet.msbuild.2.9.0-preview.7.g18a53d00b8.nupkg'.
  Successfully created package 'C:\git\coverlet\bin\Debug\Packages\coverlet.msbuild.2.9.0-preview.7.g18a53d00b8.snupkg'.
```

3) Add generated package versions to `coverlet.integration.determisticbuild.tfmtestproject`
```xml
  <ItemGroup>
    <PackageReference Include="coverlet.msbuild" Version="2.9.0-preview.7.g18a53d00b8">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="coverlet.collector" Version="1.3.0-preview.7.g18a53d00b8" />
    <PackageReference Include="xunit" />
    <PackageReference Include="xunit.runner.visualstudio" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" />
  </ItemGroup>
```
Will be used thanks to 
```xml
<RestoreSources>
    https://api.nuget.org/v3/index.json;
    $(RepoRoot)bin\$(Configuration)\Packages
</RestoreSources>
```

4) Run tests
```
C:\git\coverlet (testdet -> origin)
λ dotnet test test\coverlet.integration.determisticbuild.tfmtestproject /p:CollectCoverage=true /p:DeterministicSourcePaths=true
```