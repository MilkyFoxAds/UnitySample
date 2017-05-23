using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class MilkyFoxRewardedVideoIosBridge : MilkyFoxRewardedVideoBaseBridge {

	public MilkyFoxRewardedVideoIosBridgeListener BridgeListener { get; set; }

	[DllImport ("__Internal")]
	private static extern void MilkyFoxSDKCreateRewardedVideo(string adUnit);

	[DllImport ("__Internal")]
	private static extern void MilkyFoxSDKShowRewardedVideo();

	[DllImport ("__Internal")]
	private static extern bool MilkyFoxSDKIsRewardedVideoRedy();

	public static void MilkyFoxSDK() {

	}

	public void DidLoadAd () {
		notifyLoad ();
	}

	public void DidShow () {
		notifyShow ();
	}

	public void DidStart () {
		notifyStart ();
	}

	public void DidClose () {
		notifyClose ();
	}

	public void DidComplete () {
		notifyComplete ();
	}

	public MilkyFoxRewardedVideoIosBridge(IMilkyFoxRewardedVideoBridgeListener listener) : base(listener) {

		MilkyFoxRewardedVideoIosBridgeListener.Configure ();

		MilkyFoxRewardedVideoIosBridgeListener.instance.Bridge = this;
	}

	override public void Initialize(string adUnit) {
		MilkyFoxSDKCreateRewardedVideo(adUnit);
	}

	override public void Show() {
		MilkyFoxSDKShowRewardedVideo();
	}

	override public bool IsLoaded(){
		return MilkyFoxSDKIsRewardedVideoRedy();
	}
}

public class MilkyFoxRewardedVideoIosBridgeListener : MonoBehaviour {

	public MilkyFoxRewardedVideoIosBridge Bridge { get; set; }

	public static MilkyFoxRewardedVideoIosBridgeListener instance;

	private static void ensureInstance() {
		if(instance == null) {
			instance = FindObjectOfType( typeof(MilkyFoxRewardedVideoIosBridgeListener) ) as MilkyFoxRewardedVideoIosBridgeListener;
			if(instance == null) {
				instance = new GameObject("MilkyFoxRewardedVideoIosBridgeListener").AddComponent<MilkyFoxRewardedVideoIosBridgeListener>();
			}
		}
	}

	void Awake() {
		name = "MilkyFoxRewardedVideoIosBridgeListener";
		DontDestroyOnLoad(transform.gameObject);
	}

	public void RewardedVideoDidLoadAd(string args) {
		instance.Bridge.DidLoadAd ();
	}

	public void RewardedVideoDidShow(string args) {
		instance.Bridge.DidShow ();
	}

	public void RewardedVideoDidComplete(string args) {
		instance.Bridge.DidComplete ();
	}

	public void RewardedVideoDidStart(string args) {
		instance.Bridge.DidStart ();
	}

	public void RewardedVideoDidClose(string args) {
		instance.Bridge.DidClose ();
	}

	static public void Configure () {
		ensureInstance ();

		instance.name = "MilkyFoxRewardedVideoIosBridgeListener";
	}
}