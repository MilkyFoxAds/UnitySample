using UnityEngine;
using System.Collections;

public class MilkyFoxRewardedVideoEditorBridge : MilkyFoxRewardedVideoBaseBridge {
	public MilkyFoxRewardedVideoEditorBridge(IMilkyFoxRewardedVideoBridgeListener listener) : base(listener){
		Debug.Log("MilkyFoxRewardedVideoEditorBridge:Constructor()");
	}

	override public void Initialize(string adUnit){
		Debug.Log("MilkyFoxRewardedVideoEditorBridge:Init(). Ads should start loading on the device!");
	}

	override public void Show(){
		Debug.Log("MilkyFoxRewardedVideoEditorBridge:Show(). Ad with be shown on the device!");
	}

	override public bool IsLoaded(){
		return false;
	}
}
