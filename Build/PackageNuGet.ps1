param($scriptRoot)

$ErrorActionPreference = "Stop"
$programFilesx86 = ${Env:ProgramFiles(x86)}
$vsVersion = "14.0"
$msBuild = "$programFilesx86\MSBuild\$vsVersion\bin\msbuild.exe"
$nuGet = "$scriptRoot..\tools\NuGet.exe"
$solution = "$scriptRoot\..\Sitecore.Modules.PatchableIgnoreList.sln"

& $nuGet restore $solution
& $msBuild $solution /p:Configuration=Release /t:Rebuild /m

& $nuGet pack "$scriptRoot\..\Sitecore.Modules.PatchableIgnoreList\Sitecore.Modules.PatchableIgnoreList.csproj" -Symbols -Prop Configuration=Release -Prop VisualStudioVersion=$vsVersion