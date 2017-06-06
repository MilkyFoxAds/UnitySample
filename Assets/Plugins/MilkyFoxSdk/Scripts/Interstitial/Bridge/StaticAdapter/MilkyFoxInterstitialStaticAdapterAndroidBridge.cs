using UnityEngine;
using System;
using System.Collections;

public class MilkyFoxInterstitialStaticAdapterAndroidBridge : MilkyFoxInterstitialStaticAdapterBaseBridge {
	private AndroidJavaObject milkyFoxInterstitialStaticAdapter = null;
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



	public MilkyFoxInterstitialStaticAdapterAndroidBridge(IMilkyFoxInterstitialStaticAdapterBridgeListener listener) : base(listener){
		milkyFoxInterstitialStaticAdapter = new AndroidJavaObject("com.milkyfox.sdk.common.unity.MilkyFoxInterstitialStaticAdapterUnityBridge");

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
		milkyFoxInterstitialStaticAdapter.Call(setter, callback);
	}

	protected void RunAction(Action action) {
		if (action != null) {
			action ();
		}
	}

	override public void Initialize(string adUnit){
		milkyFoxInterstitialStaticAdapter.Call ("initialize", activity, adUnit);
	}

	override public void Show(){
		milkyFoxInterstitialStaticAdapter.Call ("show");
	}

	override public bool IsLoaded(){
		return milkyFoxInterstitialStaticAdapter.Call<bool> ("isLoaded");
	}
}
