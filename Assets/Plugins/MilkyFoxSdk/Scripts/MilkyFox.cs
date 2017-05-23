using UnityEngine;
using System.Collections;

public class MilkyFox{
	private static IMilkyFox _milkyFoxInstance = null;

	private static IMilkyFox milkyFoxInstance {
		get {
			if(_milkyFoxInstance==null){
				#if UNITY_EDITOR
				_milkyFoxInstance = new MilkyFoxEditor();
				#elif UNITY_ANDROID
				_milkyFoxInstance = new MilkyFoxAndroid();
				#elif UNITY_IOS
				_milkyFoxInstance = new MilkyFoxIos();
				#else
				_milkyFoxInstance = new MilkyFoxEditor();
				#endif
			}
			return _milkyFoxInstance;
		}
	}

	public static bool IsDebugMode(){
		return milkyFoxInstance.IsDebugMode();
	}

	public static void SetDebugMode (bool debugMode){
		milkyFoxInstance.SetDebugMode (debugMode);
	}
}
