using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonGroup : MonoBehaviour {

	public Button UpButton;
	public Button DownButton;
	public Button LeftButton;
	public Button RightButton;
	public UpdateLogic Logic;

	public void DisableButtons()
	{
		UpButton.gameObject.SetActive(false);
		DownButton.gameObject.SetActive(false);
		LeftButton.gameObject.SetActive(false);
		RightButton.gameObject.SetActive(false);
	}

	void SetupButton( Button TheButton, string Text )
	{
		TheButton.gameObject.SetActive(true);
		TheButton.GetComponentInChildren<Text>().text = Text;
	}

	public void EnableButtons( string UpText, string DownText, string LeftText, string RightText)
	{
		SetupButton(UpButton, UpText);
		SetupButton(DownButton, DownText);
		SetupButton(LeftButton, LeftText);
		SetupButton(RightButton, RightText);
	}

	void Start() {
		UpButton.onClick.AddListener(delegate { UpClicked(); } );
		DownButton.onClick.AddListener(delegate { DownClicked(); } );
		LeftButton.onClick.AddListener(delegate { LeftClicked(); } );
		RightButton.onClick.AddListener(delegate { RightClicked(); } );
	}

	public void UpClicked() {
		Logic.ButtonPushed(UpdateLogic.ButtonType.UP);
	}

	public void DownClicked() {
		Logic.ButtonPushed(UpdateLogic.ButtonType.DOWN);
	}

	public void LeftClicked() {
		Logic.ButtonPushed(UpdateLogic.ButtonType.LEFT);
	}

	public void RightClicked() {
		Logic.ButtonPushed(UpdateLogic.ButtonType.RIGHT);
	}
}
