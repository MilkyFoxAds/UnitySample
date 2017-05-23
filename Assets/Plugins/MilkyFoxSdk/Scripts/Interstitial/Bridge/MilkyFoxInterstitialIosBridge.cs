using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class MilkyFoxInterstitialIosBridge : MilkyFoxInterstitialBaseBridge {
	public static void MilkyFoxSDK() {

	}

	public void DidLoadAd () {
		notifyLoad ();
	}

	public void DidFailToLoadAd () {
		notifyFail ();
	}

	public void DidShow () {
		notifyShow ();
	}

	public void DidClick () {
		notifyClick ();
	}

	public void DidClose () {
		notifyClose ();
	}

	public MilkyFoxInterstitialIosBridge(string adUnit, IMilkyFoxInterstitialBridgeListener listener) : base(adUnit, listener) {
	}

	override public void Load(){
		//not implemented
	}

	override public void Show(){
		//not implemented
	}

	override public bool IsLoaded(){
		//not implemented
		return false;
	}

	override public void OnDestroy(){
		//not used
	}
}