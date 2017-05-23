using UnityEngine;
using System.Collections;

public interface IMilkyFoxInterstitialBridge{
	void Load();

	void Show();

	bool IsLoaded();

	void OnDestroy();
}
