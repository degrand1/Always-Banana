using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateLogic : MonoBehaviour {

	public ButtonGroup Buttons;
	public Text Content;
	public string ProfessorName;
	public string PatientName;
	public float RPGTextDelay;

	private int NumCharactersToDisplay;
	private float CurrentTime;
	private int CurrentStringLength;
	private int CurrentData;

	[System.Serializable] public class StateData {
		public string Message;
	}

	public StateData[] Data;

	// Use this for initialization
	void Start () {
		Buttons.DisableButtons();
		NumCharactersToDisplay = 0;
		CurrentTime = 0;
		CurrentData = 0;
		CurrentStringLength = Data[0].Message.Length;
		Content.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if( CurrentStringLength != NumCharactersToDisplay )
		{
			CurrentTime += Time.deltaTime;
			if( CurrentTime >= RPGTextDelay )
			{
				NumCharactersToDisplay++;
				Content.text = Data[CurrentData].Message.Substring( 0, NumCharactersToDisplay );
				CurrentTime = 0.0f;
				if( CurrentStringLength == NumCharactersToDisplay )
				{
					Buttons.EnableButtons ();
				}
			}
		}
	}
}
