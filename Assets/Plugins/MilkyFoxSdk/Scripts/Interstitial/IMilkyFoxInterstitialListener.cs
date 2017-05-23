using UnityEngine;
using System.Collections;

public interface IMilkyFoxInterstitialListener{
	void MilkyFoxInterstitialLoad();

	void MilkyFoxInterstitialFail();

	void MilkyFoxInterstitialShow();

	void MilkyFoxInterstitialClick();

	void MilkyFoxInterstitialClose();
}
