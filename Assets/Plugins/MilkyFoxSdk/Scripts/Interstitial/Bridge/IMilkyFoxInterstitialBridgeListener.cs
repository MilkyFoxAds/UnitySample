using UnityEngine;
using System.Collections;

public interface IMilkyFoxInterstitialBridgeListener{
	void MilkyFoxInterstitialBridgeLoad();

	void MilkyFoxInterstitialBridgeFail();

	void MilkyFoxInterstitialBridgeShow();

	void MilkyFoxInterstitialBridgeClick();

	void MilkyFoxInterstitialBridgeClose();
}
