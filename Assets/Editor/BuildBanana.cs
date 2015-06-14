using UnityEngine;
using UnityEditor;

public static class BuildBanana {
	static void BuildForWeb() {
		string[] levels = { "levelOne.unity" };
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.WebPlayer );
		BuildPipeline.BuildPlayer( levels, "Play", BuildTarget.WebPlayer, BuildOptions.None );
	}
}
