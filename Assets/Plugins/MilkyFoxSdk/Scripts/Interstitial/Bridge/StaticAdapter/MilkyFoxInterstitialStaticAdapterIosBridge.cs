using UnityEngine;
using System.Collections;

public class MilkyFoxInterstitialStaticAdapterIosBridge : MilkyFoxInterstitialStaticAdapterBaseBridge {
	public MilkyFoxInterstitialStaticAdapterIosBridge(IMilkyFoxInterstitialStaticAdapterBridgeListener listener) : base(listener){
		//not implemented
	}

	override public void Initialize(string adUnit){
		//not implemented
	}

	override public void Show(){
		//not implemented
	}

	override public bool IsLoaded(){
		return false;
	}
}
