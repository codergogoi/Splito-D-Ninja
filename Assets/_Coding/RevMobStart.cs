using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class RevMobStart : MonoBehaviour, IRevMobListener {
	

	private static readonly Dictionary<String, String> appIds = new Dictionary<String, String>() {
		{ "Android", "53bd47861e7735d4061ce1ad"}, // Find your RevMob App IDs in revmob.com
		{ "IOS", "53bd473bfef474d2061515a5" }
	};

	private RevMob revmob;
	private RevMobFullscreen fullscreen;
	private RevMobPopup popup;
	private RevMobLink adLink;
	private RevMobBanner banner;
  	private RevMobBanner loadedBanner;

	void OnApplicationFocus() {
	}
	
	
	void Awake(){
		
		revmob = RevMob.Start(appIds, "GameObject");
	}
	
	void Start(){

		revmob.ShowFullscreen();
	}

	
   
	#region IRevMobListener implementation
	public void SessionIsStarted() {
		Debug.Log(">>> Session Started");
	}

	public void SessionNotStarted(string message) {
		Debug.Log(">>> Session not started");
	}

	public void AdDidReceive(string revMobAdType) {
		Debug.Log(">>> AdDidReceive: " + revMobAdType);
	}

	public void AdDidFail(string revMobAdType) {
		Debug.Log(">>> AdDidFail: " + revMobAdType);
	}

	public void AdDisplayed(string revMobAdType) {
		Debug.Log(">>> AdDisplayed: " + revMobAdType);
	}

	public void UserClickedInTheAd(string revMobAdType)	{
		Debug.Log(">>> AdClicked: " + revMobAdType);
	}

	public void UserClosedTheAd(string revMobAdType) {
		Debug.Log(">>> AdClosed: " + revMobAdType);
	}

	public void InstallDidReceive(string message) {}

	public void InstallDidFail(string message) {}

	#endregion
}