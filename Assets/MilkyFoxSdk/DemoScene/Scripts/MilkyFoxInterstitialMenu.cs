using UnityEngine;
using System.Collections;

public class MilkyFoxInterstitialMenu : MonoBehaviour, IMilkyFoxInterstitialListener{
	public string adUnit = "interstitial_3405:4204";

	private MilkyFoxInterstitial milkyFoxInterstitial;
	private bool loaded = false;
	ArrayList messages = new ArrayList();

	// Use this for initialization
	void Start(){
		milkyFoxInterstitial = new MilkyFoxInterstitial (adUnit);
		milkyFoxInterstitial.SetListener (this);
	}

	void OnGUI() {

		int padding = 20;
		int buttonHeight = 30;
		int buttonInterval = 50;
		int y = Screen.height / 2 - buttonHeight - buttonInterval/2;

		GUI.color = Color.white;

		if (GUI.Button (new Rect (padding, y, Screen.width-2*padding, buttonHeight), "Load Interstitial")) {
			milkyFoxInterstitial.Load ();
		}

		y += buttonInterval+buttonHeight;

		GUI.enabled = loaded;
		if (GUI.Button (new Rect (padding, y, Screen.width-2*padding, buttonHeight), "Show")) {
			if (milkyFoxInterstitial.IsLoaded ()) {
				milkyFoxInterstitial.Show ();
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
