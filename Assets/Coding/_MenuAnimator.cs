using UnityEngine;
using System.Collections;

public class _MenuAnimator : MonoBehaviour {
	
	public GameObject PlayBtn;
	public GameObject OptionsBtn;
	public GameObject TaskBtn;
	
	private float tm;

	// Use this for initialization
	void Start () {
		
		onInit();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		tm+= Time.deltaTime * 2;
		if(tm > 3){
			 PlayBtn.animation.CrossFade("playContinue", 0.2F);
			tm = 0;
		}
	
	}
	
	public void onInit(){
		
		StartCoroutine(WaitForBgAnim(0.4f));
		StartCoroutine(WaitForRetryAnim(0.5f));
		StartCoroutine(WaitForExitAnim(0.6f));
		
	}
	
	
	
	// open Animations
	IEnumerator WaitForBgAnim(float btm){
		
		yield return new WaitForSeconds(btm);
		 TaskBtn.animation.CrossFade("tasko", 0.2F);
		
	}
	
	IEnumerator WaitForRetryAnim(float btm){
		
		yield return new WaitForSeconds(btm);
		 OptionsBtn.animation.CrossFade("optionso", 0.2F);
		
	}
	
	IEnumerator WaitForExitAnim(float btm){
		
		yield return new WaitForSeconds(btm);
		 PlayBtn.animation.CrossFade("playo", 0.2F);
		
	}
	
	
	
	
	
	
}
