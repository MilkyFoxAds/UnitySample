using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MilkyFoxInterstitial:IMilkyFoxInterstitialBridge, IMilkyFoxInterstitialBridgeListener{
	private IMilkyFoxInterstitialListener listener = null;
	private MilkyFoxInterstitialBaseBridge bridge;

	public MilkyFoxInterstitial(string adUnit){
		#if UNITY_EDITOR
		bridge = new MilkyFoxInterstitialEditorBridge(adUnit, this);
		#elif UNITY_ANDROID
		bridge = new MilkyFoxInterstitialAndroidBridge(adUnit, this);
		#elif UNITY_IOS
		bridge = new MilkyFoxInterstitialIosBridge(adUnit, this);
		#else
		bridge = new MilkyFoxInterstitialEditorBridge(adUnit, this);
		#endif
	}

	public void Load(){
		bridge.Load ();
	}

	public void Show(){
		bridge.Show ();
	}
	
	public bool IsLoaded(){
		return bridge.IsLoaded ();
	}

	public void OnDestroy(){
		bridge.OnDestroy ();
	}

	public void MilkyFoxInterstitialBridgeLoad(){
		notifyLoad ();
	}

	public void MilkyFoxInterstitialBridgeFail(){
		notifyFail ();
	}

	public void MilkyFoxInterstitialBridgeShow(){
		notifyShow ();
	}

	public void MilkyFoxInterstitialBridgeClick(){
		notifyClick ();
	}

	public void MilkyFoxInterstitialBridgeClose(){
		notifyClose ();
	}

	public void SetListener(IMilkyFoxInterstitialListener listener){
		this.listener = listener;
	}

	private void notifyLoad(){
		if (listener != null) {
			listener.MilkyFoxInterstitialLoad ();
		}
	}

	private void notifyFail(){
		if (listener != null) {
		listener.MilkyFoxInterstitialFail ();
		}
	}

	private void notifyShow(){
		if (listener != null) {
			listener.MilkyFoxInterstitialShow ();
		}
	}

	private void notifyClick(){
		if (listener != null) {
			listener.MilkyFoxInterstitialClick ();
		}
	}

	private void notifyClose(){
		if (listener != null) {
			listener.MilkyFoxInterstitialClose ();
		}
	}
}
