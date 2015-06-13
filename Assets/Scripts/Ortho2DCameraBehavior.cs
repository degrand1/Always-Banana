using UnityEngine;
using System.Collections;

public class Ortho2DCameraBehavior: MonoBehaviour {
	void Awake() {
		GetComponent<Camera>().orthographicSize = Screen.height / 2;
	}
}
