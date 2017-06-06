using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MilkyFoxInterstitialStaticAdapter:IMilkyFoxInterstitialStaticAdapterBridgeListener{
	private static IMilkyFoxInterstitialListener listener = null;

	private static MilkyFoxInterstitialStaticAdapter _instance;

	private static MilkyFoxInterstitialStaticAdapter instance
	{
		get {
			if (_instance == null) {
				_instance = new MilkyFoxInterstitialStaticAdapter();
			}
			return _instance;
		}
	}

	private static MilkyFoxInterstitialStaticAdapterBaseBridge _bridge;

	public static MilkyFoxInterstitialStaticAdapterBaseBridge bridge
	{
		get {
			if (_bridge == null) {
				#if UNITY_EDITOR
				_bridge = new MilkyFoxInterstitialStaticAdapterEditorBridge(instance);
				#elif UNITY_ANDROID
				_bridge = new MilkyFoxInterstitialStaticAdapterAndroidBridge(instance);
				#elif UNITY_IOS
				_bridge = new MilkyFoxInterstitialStaticAdapterIosBridge(instance);
				#else
				_bridge = new MilkyFoxInterstitialStaticAdapterEditorBridge(instance);
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

	public void MilkyFoxInterstitialStaticAdapterBridgeLoad(){
		notifyLoad ();
	}

	public void MilkyFoxInterstitialStaticAdapterBridgeFail(){
		notifyFail ();
	}

	public void MilkyFoxInterstitialStaticAdapterBridgeShow(){
		notifyShow ();
	}

	public void MilkyFoxInterstitialStaticAdapterBridgeClose(){
		notifyClose ();
	}

	public void MilkyFoxInterstitialStaticAdapterBridgeClick(){
		notifyClick ();
	}

	public static void SetListener(IMilkyFoxInterstitialListener listener){
		MilkyFoxInterstitialStaticAdapter.listener = listener;
	}

	private void notifyLoad(){
		if (listener!=null) {
			listener.MilkyFoxInterstitialLoad ();
		}
	}

	private void notifyFail(){
		if (listener!=null) {
			listener.MilkyFoxInterstitialFail ();
		}
	}

	private void notifyShow(){
		if (listener!=null) {
				listener.MilkyFoxInterstitialShow ();
		}
	}

	private void notifyClose(){
		if (listener!=null) {
				listener.MilkyFoxInterstitialClose ();
		}
	}

	private void notifyClick(){
		if (listener!=null) {
				listener.MilkyFoxInterstitialClick ();
		}
	}
}
