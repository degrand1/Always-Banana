using UnityEngine;
using System.Collections;

// the splash screen is basically two overlay textures (one main splash, one subtitle)
// both textures must be 800 by 600, and they are drawn centered to the screen
public class SplashScreen : MonoBehaviour {
	private Texture splashTex;
	private Texture subtitleTex;

	// Use this for initialization
	void Start () {
	 splashTex = Resources.Load( "splash/title" ) as Texture;
	 // REMOVEME
	 PlayerPrefs.SetInt( "PatientsSeen", 0 );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if ( splashTex != null ) {
			var x = ( Screen.width - splashTex.width ) / 2;
			var y = ( Screen.height - splashTex.height ) / 2;
			GUI.DrawTexture( new Rect( x, y, splashTex.width, splashTex.height ), splashTex, ScaleMode.ScaleAndCrop, true, 0.0F );
		}

		if ( subtitleTex != null ) {
			var x = ( Screen.width - subtitleTex.width ) / 2;
			var y = ( Screen.height - subtitleTex.height ) / 2;
			GUI.DrawTexture( new Rect( x, y, subtitleTex.width, subtitleTex.height ), subtitleTex, ScaleMode.ScaleAndCrop, true, 0.0F );
		}
	}

	// loads a new catchphrase
	void Refresh() {
	 PlayerPrefs.SetInt( "PatientsSeen", PlayerPrefs.GetInt( "PatientsSeen" ) + 1 );
	}
}
