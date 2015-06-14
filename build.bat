@REM if your unity editor path differs, either change it here (and do not check in your changes),
@REM or set it in your own build script and @call this script from your build script
@if defined UNITYEDITOR goto :skipSetDefaultUnityPath
@set UNITYEDITOR="C:\Program Files\Unity\Editor\Unity.exe"

:skipSetDefaultUnityPath
@set WD=%cd%
@set DIST=Builds
@if not exist %DIST% mkdir %DIST%

@REM win32
%UNITYEDITOR% -quit -batchMode -nographics -projectPath %WD% -buildTarget win32 -buildWindowsPlayer %DIST%\win32\AlwaysBanana.exe

@REM win64
%UNITYEDITOR% -quit -batchMode -nographics -projectPath %WD% -buildTarget win64 -buildWindows64Player %DIST%\win64\AlwaysBanana_x64.exe

@REM OS X
%UNITYEDITOR% -quit -batchMode -nographics -projectPath %WD% -buildTarget osx -buildOSXUniversalPlayer %DIST%\osx\AlwaysBanana.app

@REM Linux
%UNITYEDITOR% -quit -batchMode -nographics -projectPath %WD% -buildTarget linux -buildLinuxUniversalPlayer %DIST%\linux\AlwaysBanana
