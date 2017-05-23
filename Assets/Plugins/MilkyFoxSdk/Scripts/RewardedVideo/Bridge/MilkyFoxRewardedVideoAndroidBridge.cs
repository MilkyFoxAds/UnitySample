using UnityEngine;
using System;
using System.Collections;

public class MilkyFoxRewardedVideoAndroidBridge : MilkyFoxRewardedVideoBaseBridge{

	private AndroidJavaObject milkyFoxRewardedVideo = null;
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

	public MilkyFoxRewardedVideoAndroidBridge(IMilkyFoxRewardedVideoBridgeListener listener) : base(listener){
		milkyFoxRewardedVideo = new AndroidJavaObject("com.milkyfox.sdk.common.unity.MilkyFoxRewardedVideoUnityBridge");

		AssignEvent("setLoadedListener", () => RunAction(LoadedAction));
		AssignEvent("setShownListener", () => RunAction(ShownAction));
		AssignEvent("setClosedListener", () => RunAction(ClosedAction));
		AssignEvent("setStartedListener", () => RunAction(StartedAction));
		AssignEvent("setCompletedListener", () => RunAction(CompletedAction));
	}

	protected void LoadedAction(){
		notifyLoad ();
	}

	protected void ShownAction(){
		notifyShow ();
	}

	protected void ClosedAction(){
		notifyClose ();
	}

	protected void StartedAction(){
		notifyStart ();
	}

	protected void CompletedAction(){
		notifyComplete ();
	}

	protected void AssignEvent(string setter, Action listener) {
		AndroidJavaRunnable callback = delegate() {
			if (listener != null)
				listener();
		};
		milkyFoxRewardedVideo.Call(setter, callback);
	}

	protected void RunAction(Action action) {
		if (action != null) {
			action ();
		}
	}

	override public void Initialize(string adUnit){
		milkyFoxRewardedVideo.Call ("initialize", activity, adUnit);
	}

	override public void Show(){
		milkyFoxRewardedVideo.Call ("show");
	}

	override public bool IsLoaded(){
		return milkyFoxRewardedVideo.Call<bool> ("isLoaded");
	}
}
