using UnityEngine;

public class MilkyFoxInterstitialStaticAdapter {

	private static MilkyFoxInterstitial milkyFoxInterstitial = null;

	public static void Initialize (string adUnit, IMilkyFoxInterstitialListener listener) {
		milkyFoxInterstitial = new MilkyFoxInterstitial (adUnit);
		milkyFoxInterstitial.SetListener (listener);
	}

	public static void Load(){
		if (milkyFoxInterstitial != null) {
			milkyFoxInterstitial.Load ();
		}
	}

	public static bool IsLoaded(){
		if (milkyFoxInterstitial != null) {
			return milkyFoxInterstitial.IsLoaded ();
		}
		return false;
	}

	public static void Show () {
		if (milkyFoxInterstitial != null) {
			milkyFoxInterstitial.Show ();
		}
	}

}