UNITYEDITOR=/Applications/Unity/Unity.app/Contents/MacOS/Unity

WD=`pwd`
DIST=Builds

mkdir -p $DIST
mkdir -p $DIST/win32
mkdir -p $DIST/win64
mkdir -p $DIST/osx
mkdir -p $DIST/linux

# win32
$UNITYEDITOR -quit -batchMode -nographics -projectPath $WD -buildTarget win32 -buildWindowsPlayer $DIST/win32/AlwaysBanana.exe

# win64
$UNITYEDITOR -quit -batchMode -nographics -projectPath $WD -buildTarget win64 -buildWindows64Player $DIST/win32/AlwaysBanana_x64.exe

# OS X
$UNITYEDITOR -quit -batchMode -nographics -projectPath $WD -buildTarget osx -buildOSXUniversalPlayer $DIST/osx/AlwaysBanana.app

# Linux
$UNITYEDITOR -quit -batchMode -nographics -projectPath $WD -buildTarget linux -buildLinuxUniversalPlayer $DIST/linux/AlwaysBanana
