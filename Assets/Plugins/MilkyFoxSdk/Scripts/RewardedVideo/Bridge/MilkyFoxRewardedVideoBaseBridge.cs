using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MilkyFoxRewardedVideoBaseBridge:IFlybMobRewardedVideoBridge{
	private IMilkyFoxRewardedVideoBridgeListener listener;

	public MilkyFoxRewardedVideoBaseBridge(IMilkyFoxRewardedVideoBridgeListener listener){
		this.listener = listener;
	}

	public abstract void Initialize (string adUnit);

	public abstract void Show ();

	public abstract bool IsLoaded();

	protected void notifyLoad(){
		if (listener != null) {
			listener.MilkyFoxRewardedVideoBridgeLoad ();
		}
	}

	protected void notifyShow(){
		if (listener != null) {
			listener.MilkyFoxRewardedVideoBridgeShow ();
		}
	}

	protected void notifyClose(){
		if (listener != null) {
			listener.MilkyFoxRewardedVideoBridgeClose ();
		}
	}

	protected void notifyStart(){
		if (listener != null) {
			listener.MilkyFoxRewardedVideoBridgeStart ();
		}
	}

	protected void notifyComplete(){
		if (listener != null) {
			listener.MilkyFoxRewardedVideoBridgeComplete ();
		}
	}
		
}
