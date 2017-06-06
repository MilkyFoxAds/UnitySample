using UnityEngine;
using System.Collections;

public interface IMilkyFoxInterstitialStaticAdapterBridge{
	void Initialize(string adUnit);

	void Show();

	bool IsLoaded();
}
