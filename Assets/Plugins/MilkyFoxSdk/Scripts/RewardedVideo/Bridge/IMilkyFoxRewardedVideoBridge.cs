using UnityEngine;
using System.Collections;

public interface IFlybMobRewardedVideoBridge{
	void Initialize(string adUnit);

	void Show();

	bool IsLoaded();
}
