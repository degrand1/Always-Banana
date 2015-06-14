using UnityEngine;
using System.Collections;

public class ExtendWidth : MonoBehaviour {

	RectTransform rectTransform;

	void Awake() {
		rectTransform = GetComponent<RectTransform>();
	}

	void Update() {
		rectTransform.sizeDelta = new Vector2(Screen.width, rectTransform.rect.height);
	}
}
