dotnet test Ghpr.Tests.Tests\Ghpr.Core.Tests.csproj --collect:"Code Coverage"

$opencover = "$($env:USERPROFILE)\.nuget\packages\opencover\4.7.922\tools\OpenCover.Console.exe"
write-output "======= OPENCOVER PATH: " $opencover " ======="

& $opencover -register:user -target:"dotnet.exe" "-targetargs:""test Ghpr.Tests.Tests\Ghpr.Core.Tests.csproj""" -oldstyle -filter:"+[Ghpr.Core*]* -[Ghpr.Tests.Tests*]*" -output:opencoverCoverage.xml