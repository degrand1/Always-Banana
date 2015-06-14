using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateLogic : MonoBehaviour {

	public enum MessageType2 {
		THERAPIST,
		PATIENT,
		DECISION
	};

	public enum ButtonType {
		UP,
		DOWN,
		LEFT,
		RIGHT
	};

	public enum State {
		DISPLAYING_TEXT,
		DELAY_AFTER_FULL_TEXT_DISPLAY,
		WAITING_FOR_INPUT,
		PRESS_SPACE_TO_START
	};

	public ButtonGroup Buttons;
	public Text Content;
	public float RPGTextDelay;
	public float DelayAfterFullTextDisplay;
	public Color TherapistTextColor;
	public Color PatientTextColor;
	public int StartingConversation;

	private int NumCharactersToDisplay;
	private float CurrentTime;
	private int CurrentStringLength;
	private int CurrentData;
	private int CurrentPatient;
	private int MaxNumPatients;
	public State CurrentState;

	public PatientData[] Patients;
	public GameObject CurrentPatientObject;

	// Use this for initialization
	void Start () {
		Buttons.DisableButtons();
		NumCharactersToDisplay = 0;
		CurrentTime = 0;
		CurrentData = 0;
		MaxNumPatients = Patients.Length;
		CurrentPatient = StartingConversation != -1 ? StartingConversation : Random.Range(0, MaxNumPatients);
		CurrentStringLength = Patients[CurrentPatient].Data[CurrentData].Message.Length;
		Content.text = "";
		//Assume the therapist or patient will always begin the conversation
		Content.color = Patients[CurrentPatient].Data[CurrentData].Type == MessageType.THERAPIST ? TherapistTextColor : PatientTextColor;
		CurrentState = State.PRESS_SPACE_TO_START;
		CurrentPatientObject.GetComponent<SpriteRenderer>().sprite = Patients[CurrentPatient].GetComponent<SpriteRenderer>().sprite;
	}
	
	void UpdateTextDisplay()
	{
		CurrentTime += Time.deltaTime;
		if( CurrentTime >= RPGTextDelay )
		{
			NumCharactersToDisplay++;
			Content.text = Patients[CurrentPatient].Data[CurrentData].Message.Substring( 0, NumCharactersToDisplay );
			CurrentTime = 0.0f;
			if( CurrentStringLength == NumCharactersToDisplay )
			{
				CurrentState = State.DELAY_AFTER_FULL_TEXT_DISPLAY;
			}
		}
	}

	void LoadPushStartOverlay()
	{
		GetComponent<SplashScreen>().RefreshAndShow();
	}

	void RemovePushStartOverlay()
	{
		GetComponent<SplashScreen>().FadeOut();
	}

	void BeginSession()
	{
		CurrentState = State.PRESS_SPACE_TO_START;
		LoadPushStartOverlay();
	}

	void SeeNextPatient()
	{
		//Don't want to see the same patient twice in a row
		int LastPatientSeen = CurrentPatient;
		CurrentPatient = Random.Range( 0, MaxNumPatients );
		if( CurrentPatient == LastPatientSeen ) CurrentPatient++;
		if( CurrentPatient >= MaxNumPatients ) CurrentPatient = 0;
		CurrentData = 0;
		UpdateTextState();
		CurrentState = State.WAITING_FOR_INPUT;
		CurrentPatientObject.GetComponent<SpriteRenderer>().sprite = Patients[CurrentPatient].GetComponent<SpriteRenderer>().sprite;
		GetComponent<BlackScreen>().FadeFromBlack( BeginSession );
	}

	void UpdateTextState()
	{
		CurrentState = State.DISPLAYING_TEXT;
		Content.color = Patients[CurrentPatient].Data[CurrentData].Type == MessageType.THERAPIST ? TherapistTextColor : PatientTextColor;
		NumCharactersToDisplay = 0;
		CurrentStringLength = Patients[CurrentPatient].Data[CurrentData].Message.Length;
		Content.text = "";
	}

	void UpdateDelay()
	{
		CurrentTime += Time.deltaTime;
		if( CurrentTime >= DelayAfterFullTextDisplay )
		{
			CurrentTime = 0.0f;
			if( Patients[CurrentPatient].Data[CurrentData].IsFinalMessage )
			{
				//load landing screen
				CurrentState = State.WAITING_FOR_INPUT;
				GetComponent<BlackScreen>().FadeToBlack( SeeNextPatient );
			}
			else
			{
				CurrentData++;
				if( Patients[CurrentPatient].Data[CurrentData].Type == MessageType.DECISION )
				{
					Buttons.EnableButtons( Patients[CurrentPatient].Data[CurrentData].UpText, Patients[CurrentPatient].Data[CurrentData].DownText, 
					                      Patients[CurrentPatient].Data[CurrentData].LeftText, Patients[CurrentPatient].Data[CurrentData].RightText );
					CurrentState = State.WAITING_FOR_INPUT;
				}
				else
				{
					UpdateTextState();
				}
			}
		}
	}

	public void ButtonPushed( ButtonType Type )
	{
		switch( Type )
		{
		case ButtonType.UP:    CurrentData = Patients[CurrentPatient].Data[CurrentData].UpIndex;    break;
		case ButtonType.DOWN:  CurrentData = Patients[CurrentPatient].Data[CurrentData].DownIndex;  break;
		case ButtonType.LEFT:  CurrentData = Patients[CurrentPatient].Data[CurrentData].LeftIndex;  break;
		case ButtonType.RIGHT: CurrentData = Patients[CurrentPatient].Data[CurrentData].RightIndex; break;
		}
		UpdateTextState();
		Buttons.DisableButtons();
	}

	void Update () {
		switch( CurrentState )
		{
		case State.DISPLAYING_TEXT:
			UpdateTextDisplay();
			break;
		case State.DELAY_AFTER_FULL_TEXT_DISPLAY:
			UpdateDelay();
			break;
		case State.WAITING_FOR_INPUT:
			break;
		case State.PRESS_SPACE_TO_START:
			if( Input.GetKeyDown(KeyCode.Space) )
			{
				RemovePushStartOverlay();
				CurrentState = State.DISPLAYING_TEXT;
			}
			break;
		}
	}
}
