using UnityEngine;
using System.Collections;

public class MilkyFoxInterstitialStaticMenu : MonoBehaviour, IMilkyFoxInterstitialListener{
	public string adUnit = "interstitial_3402:4203";

	private bool loaded = false;
	ArrayList messages = new ArrayList();

	// Use this for initialization
	void Start(){
		MilkyFoxInterstitialStaticAdapter.Initialize (adUnit, this);
	}

	void OnGUI() {

		int padding = 20;
		int buttonHeight = 30;
		int buttonInterval = 50;
		int y = Screen.height / 2 - buttonHeight - buttonInterval/2;

		GUI.color = Color.white;

		if (GUI.Button (new Rect (padding, y, Screen.width-2*padding, buttonHeight), "Load Interstitial")) {
			MilkyFoxInterstitialStaticAdapter.Load ();
		}

		y += buttonInterval+buttonHeight;

		GUI.enabled = loaded;
		if (GUI.Button (new Rect (padding, y, Screen.width-2*padding, buttonHeight), "Show")) {
			if (MilkyFoxInterstitialStaticAdapter.IsLoaded ()) {
				MilkyFoxInterstitialStaticAdapter.Show ();
			}
			loaded = false;

		}
		y += buttonInterval+buttonHeight;

		GUI.enabled = true;

		GUI.color = Color.black;
		for (int i = messages.Count-1; i>=0 && i > (messages.Count-10); i--) {
			GUI.Label (new Rect (padding, y, (Screen.width-2*padding), 20), (string)(messages[i]));
			y += 20;
		}
	}

	public void MilkyFoxInterstitialLoad(){
		Debug.Log ("Load");
		messages.Add ("Load");
		loaded = true;
	}

	public void MilkyFoxInterstitialFail(){
		Debug.Log ("Fail");
		messages.Add ("Fail");
	}

	public void MilkyFoxInterstitialShow(){
		Debug.Log ("Show");
		messages.Add ("Show");
	}

	public void MilkyFoxInterstitialClick(){
		Debug.Log ("Click");
		messages.Add ("Click");
	}

	public void MilkyFoxInterstitialClose(){
		Debug.Log ("Close");
		messages.Add ("Close");
	}
}
