using UnityEngine;
using System.Collections;

public enum MessageType {
	THERAPIST,
	PATIENT,
	DECISION
};

public class PatientData : MonoBehaviour {
	
	[System.Serializable] public class StateData {
		public string Message, UpText, DownText, LeftText, RightText;
		public MessageType Type;
		public int UpIndex, DownIndex, LeftIndex, RightIndex;
		public bool IsFinalMessage;
	}
	
	public StateData[] Data;
}
