using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MilkyFoxRewardedVideo:IMilkyFoxRewardedVideoBridgeListener{
	private static IMilkyFoxRewardedVideoListener listener = null;

	private static MilkyFoxRewardedVideo _instance;

	private static MilkyFoxRewardedVideo instance
	{
		get {
			if (_instance == null) {
				_instance = new MilkyFoxRewardedVideo();
			}
			return _instance;
		}
	}

	private static MilkyFoxRewardedVideoBaseBridge _bridge;

	public static MilkyFoxRewardedVideoBaseBridge bridge
	{
		get {
			if (_bridge == null) {
				#if UNITY_EDITOR
				_bridge = new MilkyFoxRewardedVideoEditorBridge(instance);
				#elif UNITY_ANDROID
				_bridge = new MilkyFoxRewardedVideoAndroidBridge(instance);
				#elif UNITY_IOS
				_bridge = new MilkyFoxRewardedVideoIosBridge(instance);
				#else
				_bridge = new MilkyFoxRewardedVideoEditorBridge(instance);
				#endif
			}
			return _bridge;
		}
	}

	public static void Initialize(string adUnit){
		bridge.Initialize(adUnit);
	}

	public static void Show(){
		bridge.Show ();
	}

	public static bool IsLoaded(){
		return bridge.IsLoaded ();
	}

	public void MilkyFoxRewardedVideoBridgeLoad(){
		notifyLoad ();
	}

	public void MilkyFoxRewardedVideoBridgeShow(){
		notifyShow ();
	}

	public void MilkyFoxRewardedVideoBridgeClose(){
		notifyClose ();
	}

	public void MilkyFoxRewardedVideoBridgeStart(){
		notifyStart ();
	}

	public void MilkyFoxRewardedVideoBridgeComplete(){
		notifyComplete ();
	}

	public static void SetListener(IMilkyFoxRewardedVideoListener listener){
		MilkyFoxRewardedVideo.listener = listener;
	}

	private void notifyLoad(){
		if (listener!=null) {
			listener.MilkyFoxRewardedVideoLoad ();
		}
	}

	private void notifyShow(){
		if (listener!=null) {
			listener.MilkyFoxRewardedVideoShow ();
		}
	}

	private void notifyClose(){
		if (listener!=null) {
			listener.MilkyFoxRewardedVideoClose ();
		}
	}

	private void notifyStart(){
		if (listener!=null) {
			listener.MilkyFoxRewardedVideoStart ();
		}
	}

	private void notifyComplete(){
		if (listener!=null) {
			listener.MilkyFoxRewardedVideoComplete ();
		}
	}
}
