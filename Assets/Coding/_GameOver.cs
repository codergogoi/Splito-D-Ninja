using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;


public class _GameOver : MonoBehaviour,IRevMobListener {
	
	

	public GameObject ADColony;
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
	
	
	
	public GameObject GameOverBg;
	public GameObject RetryBtn;
	public GameObject ExitBtn;

	
	
	void Start(){

		revmob = RevMob.Start(appIds, "GameObject");
	}

	

	// Update is called once per frame
	void Update () {
	
	}
	
	public void onInit(){
		
		StartCoroutine(WaitForBgAnim(0.2f));
		StartCoroutine(WaitForRetryAnim(0.3f));
		StartCoroutine(WaitForExitAnim(0.5f));
		StartCoroutine(WaitForRM(0.5f));
		
	}
	
	public void onExit(){
		
		StartCoroutine(WaitForBgAnimE(0.2f));
		StartCoroutine(WaitForRetryAnimE(0.3f));
		StartCoroutine(WaitForExitAnimE(0.5f));
		
	}
	//
	
	IEnumerator WaitForRM(float btm){
		
		yield return new WaitForSeconds(btm);

		int TryTimes = PlayerPrefs.GetInt("TRYTIMES");

		if(TryTimes > 5){
			TryTimes = 0;
			PlayerPrefs.SetInt("TRYTIMES",TryTimes);
			int CountDown = PlayerPrefs.GetInt("TRYCDTime"); 
			CountDown+= 5;
			PlayerPrefs.SetInt("TRYCDTime",CountDown);
			ADColony.SendMessage("ShowVideoAdd");
		}else{
			revmob.ShowFullscreen();
		}

		TryTimes+= 1;
		PlayerPrefs.SetInt("TRYTIMES",TryTimes);
	}
	
	
	// open Animations
	IEnumerator WaitForBgAnim(float btm){
		
		yield return new WaitForSeconds(btm);
		 GameOverBg.animation.CrossFade("over_O", 0.2F);
		
	}
	
	IEnumerator WaitForRetryAnim(float btm){
		
		yield return new WaitForSeconds(btm);
		 RetryBtn.animation.CrossFade("retry_O", 0.2F);
		
	}
	
	IEnumerator WaitForExitAnim(float btm){
		
		yield return new WaitForSeconds(btm);
		 ExitBtn.animation.CrossFade("exit_O", 0.2F);
		
	}
	
	//Close Animation
	
	// open Animations
	IEnumerator WaitForBgAnimE(float btm){
		
		yield return new WaitForSeconds(btm);
		 GameOverBg.animation.CrossFade("over_e", 0.2F);
		
	}
	
	IEnumerator WaitForRetryAnimE(float btm){
		
		yield return new WaitForSeconds(btm);
		 RetryBtn.animation.CrossFade("retry_e", 0.2f);
		
	}
	
	IEnumerator WaitForExitAnimE(float btm){
		
		yield return new WaitForSeconds(btm);
		 ExitBtn.animation.CrossFade("exit_e",0.2f);
		
	}
	
}
