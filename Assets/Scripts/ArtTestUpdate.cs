using UnityEngine;
using System.Collections;

public class ArtTestUpdate : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKey( "space" ) ) {
			if ( GetComponent<BlackScreen>() != null ) {
				GetComponent<BlackScreen>().FadeToBlack();
			}
		}

		if ( Input.GetKey( "backspace" ) ) {
			if ( GetComponent<BlackScreen>() != null ) {
				GetComponent<BlackScreen>().FadeFromBlack();
			}
		}

		// fade in and out using DoneAction/delegate
		if ( Input.GetKey( "delete" ) ) {
			if ( GetComponent<BlackScreen>() != null ) {
				GetComponent<BlackScreen>().FadeToBlack( () => {
					// do stuff
					GetComponent<BlackScreen>().FadeFromBlack();
				} );
			}
		}
	}
}
