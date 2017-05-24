using UnityEngine;
using System.Collections;

public class MilkyFoxRewardedVideoMenu : MonoBehaviour, IMilkyFoxRewardedVideoListener{
	public string adUnit = "video_3403:4203";

	private bool inited = false;

	ArrayList messages = new ArrayList();

	// Use this for initialization
	void Start(){

	}

	void OnGUI() {

		int padding = 20;
		int buttonHeight = 30;
		int buttonInterval = 50;
		int y = Screen.height / 2 - buttonHeight - buttonInterval/2;

		GUI.color = Color.white;

		GUI.enabled = !inited;
		if (GUI.Button (new Rect (padding, y, Screen.width-2*padding, buttonHeight), "Initialize")) {
			MilkyFoxRewardedVideo.Initialize(adUnit);
			MilkyFoxRewardedVideo.SetListener (this);
			inited = true;
		}

		y += buttonInterval+buttonHeight;

		GUI.enabled = MilkyFoxRewardedVideo.IsLoaded ();
		if (GUI.Button (new Rect (padding, y, Screen.width-2*padding, buttonHeight), "Show")) {
			MilkyFoxRewardedVideo.Show ();
		}
		y += buttonInterval+buttonHeight;

		GUI.enabled = true;

		GUI.color = Color.black;

		for (int i = messages.Count-1; i>=0 && i > (messages.Count-10); i--) {
			GUI.Label (new Rect (padding, y, (Screen.width-2*padding), 20), (string)(messages[i]));
			y += 20;
		}
	}

	public void MilkyFoxRewardedVideoLoad(){
		Debug.Log ("Load");
		messages.Add ("Load");
	}

	public void MilkyFoxRewardedVideoShow(){
		Debug.Log ("Show");
		messages.Add ("Show");
	}

	public void MilkyFoxRewardedVideoClose(){
		Debug.Log ("Close");
		messages.Add ("Close");
	}

	public void MilkyFoxRewardedVideoStart(){
		Debug.Log ("Start");
		messages.Add ("Start");
	}


	public void MilkyFoxRewardedVideoComplete(){
		Debug.Log ("Complete");
		messages.Add ("Complete");
		//reward user here
	}
		
}
