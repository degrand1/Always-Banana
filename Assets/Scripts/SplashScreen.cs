using UnityEngine;
using System.Collections;

// the splash screen is basically two overlay textures (one main splash, one subtitle)
// both textures must be 800 by 600, and they are drawn centered to the screen
public class SplashScreen : MonoBehaviour {
	private Texture splashTex;
	private Texture subtitleTex;
	public Texture2D[] subtitleTexList;

	// Use this for initialization
	void Start () {
	 splashTex = Resources.Load( "splash/title" ) as Texture;
	 var data = Resources.LoadAll( "splash/sub", typeof( Texture ) );

	 subtitleTexList = new Texture2D[ data.Length ];
	 for ( var i = 0; i < data.Length; i++ ) {
		subtitleTexList[i] = data[i] as Texture2D;
	 }

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
	public void Refresh() {
		PlayerPrefs.SetInt( "PatientsSeen", PlayerPrefs.GetInt( "PatientsSeen" ) + 1 );
		var subtitleIndex = PlayerPrefs.GetInt( "PatientsSeen" ) - 1; // the first time we run the game, the subtitle is blank (null), by design
		if ( subtitleIndex >= subtitleTexList.Length ) {
			subtitleTex = null;
		} else {
			subtitleTex = subtitleTexList[ subtitleIndex ];
		}
	}
}
