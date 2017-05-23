using UnityEngine;
using System.Collections;

public class MilkyFoxInterstitialEditorBridge : MilkyFoxInterstitialBaseBridge{
	public MilkyFoxInterstitialEditorBridge(string adUnit, IMilkyFoxInterstitialBridgeListener listener) : base(adUnit, listener){
		Debug.Log(string.Format("MilkyFoxInterstitialEditorBridge:Constructor(). You inited ad with adUnit {0}", adUnit));
	}

	override public void Load(){
		Debug.Log("MilkyFoxInterstitialEditorBridge:Load(). Ad should start loading on the device!");
	}

	override public void Show(){
		Debug.Log("MilkyFoxInterstitialEditorBridge:Show(). Ad with be shown on the device!");
	}

	override public bool IsLoaded(){
		return false;
	}

	override public void OnDestroy(){
		Debug.Log("MilkyFoxInterstitialEditorBridge:OnDestroy().");
	}
}
