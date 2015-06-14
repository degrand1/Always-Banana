using UnityEngine;
using UnityEditor;

public static class BuildBanana {
	[MenuItem("BuildBanana/Deploy")]
	static void Deploy() {
		string[] scenes = new string[EditorBuildSettings.scenes.Length];
		for(int i = 0; i < scenes.Length; i++)
		{
			scenes[i] = EditorBuildSettings.scenes[i].path;
		}
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.WebPlayer );
		BuildPipeline.BuildPlayer( scenes, "Play", BuildTarget.WebPlayer, BuildOptions.None );
		scenes = null;
	}
}
