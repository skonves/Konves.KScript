nuget install OpenCover -Version 4.6.519 -OutputDirectory tools

.\tools\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:"vstest.console" -filter:"+[*]* -[*.*Tests]*" -targetargs:"/nologo /testcontainer:.\tests\Konves.KScript.UnitTests\bin\Debug\Konves.KScript.UnitTests.dll" -register:user