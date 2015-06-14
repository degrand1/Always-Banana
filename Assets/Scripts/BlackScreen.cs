using UnityEngine;
using System.Collections;

public class BlackScreen: MonoBehaviour {
	public Texture blackTex;

	private float alphaFadeValue;
	public float fadeTimeSeconds = 2; // seconds

	private const float TO_BLACK = 1;
	private const float FROM_BLACK = -1;
	private const float HOLD = 0;
	private float fadeDirection;

	public delegate void DoneAction();
	DoneAction doneAction;

	// Use this for initialization
	void Start () {
		alphaFadeValue = 0;
		fadeTimeSeconds = 2;
		fadeDirection = HOLD;
		doneAction = null;
	}
	
	// Update is called once per frame
	void Update () {
	}

	// multiple times per frame
	void OnGUI() {
		alphaFadeValue += fadeDirection * Mathf.Clamp01( Time.deltaTime / fadeTimeSeconds );
		Color oldColor = GUI.color;
		GUI.color = new Color( 0, 0, 0, alphaFadeValue );
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), blackTex, ScaleMode.StretchToFill, true, 10.0F );
		GUI.color = oldColor;

		// hold state if overboard in either direction
		if ( alphaFadeValue < 0 || alphaFadeValue > 1 ) {
			fadeDirection = HOLD;
			alphaFadeValue = Mathf.Clamp01( alphaFadeValue );
			if ( doneAction != null ) {
				DoneAction OldDoneAction = doneAction;
				doneAction();
				//null out the doneAction unless we assigned a new one
				if( OldDoneAction == doneAction ) doneAction = null;
			}
		}
	}

	public void FadeToBlack( DoneAction doneAction = null ) {
		fadeDirection = TO_BLACK;
		alphaFadeValue = 0;
		this.doneAction = doneAction;
	}

	public void FadeFromBlack( DoneAction doneAction = null ) {
		fadeDirection = FROM_BLACK;
		alphaFadeValue = 1;
		this.doneAction = doneAction;
	}
}
