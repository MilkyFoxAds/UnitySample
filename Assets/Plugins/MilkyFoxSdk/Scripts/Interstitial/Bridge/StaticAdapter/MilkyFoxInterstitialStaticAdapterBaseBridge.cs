using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MilkyFoxInterstitialStaticAdapterBaseBridge:IMilkyFoxInterstitialStaticAdapterBridge{
	private IMilkyFoxInterstitialStaticAdapterBridgeListener listener;

	public MilkyFoxInterstitialStaticAdapterBaseBridge(IMilkyFoxInterstitialStaticAdapterBridgeListener listener){
		this.listener = listener;
	}

	public abstract void Initialize (string adUnit);

	public abstract void Show ();

	public abstract bool IsLoaded();

	protected void notifyLoad(){
		if (listener != null) {
			listener.MilkyFoxInterstitialStaticAdapterBridgeLoad ();
		}
	}

	protected void notifyFail(){
		if (listener != null) {
			listener.MilkyFoxInterstitialStaticAdapterBridgeFail ();
		}
	}

	protected void notifyShow(){
		if (listener != null) {
			listener.MilkyFoxInterstitialStaticAdapterBridgeShow ();
		}
	}

	protected void notifyClick(){
		if (listener != null) {
			listener.MilkyFoxInterstitialStaticAdapterBridgeClick ();
		}
	}

	protected void notifyClose(){
		if (listener != null) {
			listener.MilkyFoxInterstitialStaticAdapterBridgeClose ();
		}
	}
}
