@echo off

IF NOT EXIST "nuspec/OpenSilverForBlazor.nuspec" (
echo Wrong working directory. Please navigate to the folder that contains the BAT file before executing it.
PAUSE
EXIT
)

rem Define the escape character for colored text
for /F %%a in ('"prompt $E$S & echo on & for %%b in (1) do rem"') do set "ESC=%%a"

rem look for the file containing the scripts location. If not found, ask the user and create it, otherwise, read it.
IF NOT EXIST "ScriptsLocation.txt" (
rem Define the "%PackageVersion%" variable:
set /p ScriptFilesLocation="js/css files location:%ESC%[0m "

rem copy the new location in a txt file so we don't have to ask for it again:
@echo %ScriptFilesLocation%> ScriptsLocation.txt
) ELSE (
rem reading the file to get the location:
FOR /F "tokens=* delims=" %%x in (ScriptsLocation.txt) DO set ScriptFilesLocation=%%x
)

rem Copy the script files
@echo Getting script files from %ScriptFilesLocation%...
xcopy /y %ScriptFilesLocation% "..\js_css\"


rem Define the "%PackageVersion%" variable:
set /p PackageVersion="%ESC%[92mOpenSilverForBlazor version:%ESC%[0m 1.1.0-private-"

rem Get the current date and time:
for /F "tokens=2" %%i in ('date /t') do set currentdate=%%i
set currenttime=%time%

rem Create a Version.txt file with the date:
md temp
@echo OpenSilverForBlazor 1.1.0-private-%PackageVersion% (%currentdate% %currenttime%)> temp/Version.txt

rem echo. 
rem echo %ESC%[95mRestoring NuGet packages%ESC%[0m
rem echo. 
rem nuget restore ../src/OpenSilverForBlazor.sln -v quiet

echo. 
echo %ESC%[95mBuilding %ESC%[0mDebug %ESC%[95mconfiguration%ESC%[0m
echo. 
msbuild src/OpenSilver.Blazor/OpenSilver.Blazor.csproj -p:Configuration=Debug -clp:ErrorsOnly -restore
echo. 
echo %ESC%[95mPacking %ESC%[0mOpenSilverForBlazor %ESC%[95mNuGet package%ESC%[0m
echo. 
nuget.exe pack nuspec\OpenSilverForBlazor.nuspec -OutputDirectory "output/OpenSilverForBlazor" -Properties "PackageId=OpenSilverForBlazor;PackageVersion=1.1.0-private-%PackageVersion%;Configuration=Debug;Target=OpenSilverForBlazor;RepositoryUrl=https://github.com/OpenSilver/OpenSilverForBlazor"

explorer "output\OpenSilverForBlazor"

pause
