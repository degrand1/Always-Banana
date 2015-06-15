using UnityEngine;
using UnityEditor;

public static class BuildBanana {
	static string[] GetAllScenePaths() {
		string[] scenes = new string[EditorBuildSettings.scenes.Length];
		for(int i = 0; i < scenes.Length; i++) {
			scenes[i] = EditorBuildSettings.scenes[i].path;
		}
		return scenes;
	}

	[MenuItem("BuildBanana/Deploy For Web")]
	static void DeployWebBuild() {
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.WebPlayer );
		BuildPipeline.BuildPlayer( GetAllScenePaths(), "Play", BuildTarget.WebPlayer, BuildOptions.None );
	}

	[MenuItem("BuildBanana/Build/All")]
	static void BuildAll() {
		BuildWin32();
		BuildWin64();
		BuildOSX();
		BuildLinux();
	}

	[MenuItem("BuildBanana/Build/Win32")]
	static void BuildWin32() {
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.StandaloneWindows );
		BuildPipeline.BuildPlayer( GetAllScenePaths(), "Builds/win32/AlwaysBanana.exe", BuildTarget.StandaloneWindows, BuildOptions.None );
	}

	[MenuItem("BuildBanana/Build/Win64")]
	static void BuildWin64() {
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.StandaloneWindows64 );
		BuildPipeline.BuildPlayer( GetAllScenePaths(), "Builds/win64/AlwaysBanana_x64.exe", BuildTarget.StandaloneWindows64, BuildOptions.None );
	}

	[MenuItem("BuildBanana/Build/OS X")]
	static void BuildOSX() {
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.StandaloneOSXUniversal );
		BuildPipeline.BuildPlayer( GetAllScenePaths(), "Builds/osx/AlwaysBanana.app", BuildTarget.StandaloneOSXUniversal, BuildOptions.None );
	}

	[MenuItem("BuildBanana/Build/Linux")]
	static void BuildLinux() {
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.StandaloneLinux );
		BuildPipeline.BuildPlayer( GetAllScenePaths(), "Builds/linux/AlwaysBanana", BuildTarget.StandaloneLinux, BuildOptions.None );
	}
}
