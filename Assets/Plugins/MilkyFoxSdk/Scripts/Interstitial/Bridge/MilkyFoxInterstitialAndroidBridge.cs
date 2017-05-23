using UnityEngine;
using System;
using System.Collections;

public class MilkyFoxInterstitialAndroidBridge : MilkyFoxInterstitialBaseBridge, System.IDisposable{

	private AndroidJavaObject milkyFoxInterstitial = null;
	private static AndroidJavaObject _activity = null;

	private AndroidJavaObject activity {
		get {
			if(_activity==null){
				AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				_activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");		
			}
			return _activity;
		}
	}

	public void Dispose() {
		OnDestroy();
	}	

	public MilkyFoxInterstitialAndroidBridge(string adUnit, IMilkyFoxInterstitialBridgeListener listener) : base(adUnit, listener){
		milkyFoxInterstitial = new AndroidJavaObject("com.milkyfox.sdk.common.unity.MilkyFoxInterstitialUnityBridge", activity, adUnit);

		AssignEvent("setLoadListener", () => RunAction(LoadAction));
		AssignEvent("setFailListener", () => RunAction(FailAction));
		AssignEvent("setShowListener", () => RunAction(ShowAction));
		AssignEvent("setClickListener", () => RunAction(ClickAction));
		AssignEvent("setCloseListener", () => RunAction(CloseAction));
	}

	protected void LoadAction(){
		notifyLoad ();
	}

	protected void FailAction(){
		notifyFail ();
	}

	protected void ShowAction(){
		notifyShow ();
	}

	protected void ClickAction(){
		notifyClick ();
	}

	protected void CloseAction(){
		notifyClose ();
	}

	protected void AssignEvent(string setter, Action listener) {
		AndroidJavaRunnable callback = delegate() {
			if (listener != null)
				listener();
		};
		milkyFoxInterstitial.Call(setter, callback);
	}

	protected void RunAction(Action action) {
		if (action != null) {
			action ();
		}
	}

	override public void Load(){
		milkyFoxInterstitial.Call ("load");
	}

	override public void Show(){
		milkyFoxInterstitial.Call ("show");
	}

	override public bool IsLoaded(){
		return milkyFoxInterstitial.Call<bool> ("isLoaded");
	}

	override public void OnDestroy(){
		if (milkyFoxInterstitial != null) {
			AssignEvent("setLoadedListener", null);
			AssignEvent("setFailedListener", null);
			AssignEvent("setShownListener", null);
			AssignEvent("setClickedListener", null);
			AssignEvent("setClosedListener", null);
			AssignEvent("setExpiredListener", null);

			milkyFoxInterstitial.Call ("onDestroy");
			milkyFoxInterstitial.Dispose();
			milkyFoxInterstitial = null;
		}	
	}
}
