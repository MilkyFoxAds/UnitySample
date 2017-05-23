using UnityEngine;
using System.Collections;

public class MilkyFoxEditor : IMilkyFox {
	public bool IsDebugMode(){
		Debug.Log("MilkyFoxEditor:IsDebugMode()");
		return false;
	}

	public void SetDebugMode (bool debugMode){
		Debug.Log("SetDebugMode:SetDebugMode()");
	}
}
