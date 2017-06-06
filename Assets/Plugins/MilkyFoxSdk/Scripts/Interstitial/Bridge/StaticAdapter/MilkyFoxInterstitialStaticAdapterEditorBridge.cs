using UnityEngine;
using System.Collections;

public class MilkyFoxInterstitialStaticAdapterEditorBridge : MilkyFoxInterstitialStaticAdapterBaseBridge {
	public MilkyFoxInterstitialStaticAdapterEditorBridge(IMilkyFoxInterstitialStaticAdapterBridgeListener listener) : base(listener){
		Debug.Log("MilkyFoxInterstitialStaticAdapterEditorBridge:Constructor()");
	}

	override public void Initialize(string adUnit){
		Debug.Log("MilkyFoxInterstitialStaticAdapterEditorBridge:Initialize(). Ads should start loading on the device!");
	}

	override public void Show(){
		Debug.Log("MilkyFoxInterstitialStaticAdapterEditorBridge:Show(). Ad with be shown on the device!");
	}

	override public bool IsLoaded(){
		return false;
	}
}
