UNITYEDITOR=/Applications/Unity/Unity.app/Contents/MacOS/Unity

WD=`pwd`
DIST=Play

mkdir -p $DIST

$UNITYEDITOR -quit -batchMode -nographics -projectPath $WD -buildTarget web -buildWebPlayer $DIST

git add $DIST
git commit


git subtree push --prefix %DIST% origin gh-pages
