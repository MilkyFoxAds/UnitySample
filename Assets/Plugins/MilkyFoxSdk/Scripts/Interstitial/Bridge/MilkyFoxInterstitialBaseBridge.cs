using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MilkyFoxInterstitialBaseBridge:IMilkyFoxInterstitialBridge{
	private IMilkyFoxInterstitialBridgeListener listener;
	protected string adUnit;

	public MilkyFoxInterstitialBaseBridge(string adUnit, IMilkyFoxInterstitialBridgeListener listener){
		this.adUnit = adUnit;
		this.listener = listener;
	}

	public abstract void Load ();

	public abstract void Show ();

	public abstract bool IsLoaded();

	public abstract void OnDestroy ();

	protected void notifyLoad(){
		if (listener != null) {
			listener.MilkyFoxInterstitialBridgeLoad ();
		}
	}

	protected void notifyFail(){
		if (listener != null) {
			listener.MilkyFoxInterstitialBridgeFail ();
		}
	}

	protected void notifyShow(){
		if (listener != null) {
			listener.MilkyFoxInterstitialBridgeShow ();
		}
	}

	protected void notifyClick(){
		if (listener != null) {
			listener.MilkyFoxInterstitialBridgeClick ();
		}
	}

	protected void notifyClose(){
		if (listener != null) {
			listener.MilkyFoxInterstitialBridgeClose ();
		}
	}
}
