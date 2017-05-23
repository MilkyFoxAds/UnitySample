using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class MilkyFoxIos : IMilkyFox {
	public bool IsDebugMode() {
		return false;
//		return MilkyFoxSDKIsDebugMode();
	}

	public void SetDebugMode (bool debugMode) {
//		MilkyFoxSDKSetDebugMode (debugMode);
	}
}
