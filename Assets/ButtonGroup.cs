using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonGroup : MonoBehaviour {

	public Button UpButton;
	public Button DownButton;
	public Button LeftButton;
	public Button RightButton;

	public void DisableButtons()
	{
		UpButton.gameObject.SetActive(false);
		DownButton.gameObject.SetActive(false);
		LeftButton.gameObject.SetActive(false);
		RightButton.gameObject.SetActive(false);
	}

	public void EnableButtons()
	{
		UpButton.gameObject.SetActive(true);
		DownButton.gameObject.SetActive(true);
		LeftButton.gameObject.SetActive(true);
		RightButton.gameObject.SetActive(true);
	}

	void Start() {
		UpButton.onClick.AddListener(delegate { UpClicked(); } );
		DownButton.onClick.AddListener(delegate { DownClicked(); } );
		LeftButton.onClick.AddListener(delegate { LeftClicked(); } );
		RightButton.onClick.AddListener(delegate { RightClicked(); } );
	}

	public void UpClicked() {
		Debug.Log ("Up button clicked");
	}

	public void DownClicked() {
		Debug.Log ("Down button clicked");
	}

	public void LeftClicked() {
		Debug.Log ("Left button clicked");
	}

	public void RightClicked() {
		Debug.Log ("Right button clicked");
	}
}
