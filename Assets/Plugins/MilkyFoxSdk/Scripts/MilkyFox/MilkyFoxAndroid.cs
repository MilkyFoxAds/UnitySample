using UnityEngine;
using System.Collections;

public class MilkyFoxAndroid : IMilkyFox {

	private AndroidJavaObject _milkyFoxAndroid = null;

	private AndroidJavaObject milkyFoxAndroid {
		get {
			if(_milkyFoxAndroid==null){
				_milkyFoxAndroid = new AndroidJavaClass("com.milkyfox.sdk.common.MilkyFox");
			}
			return _milkyFoxAndroid;
		}
	}

	public bool IsDebugMode(){
		return milkyFoxAndroid.CallStatic<bool> ("isDebugMode");
	}

	public void SetDebugMode (bool debugMode){
		milkyFoxAndroid.CallStatic("setDebugMode", debugMode);
	}
}
