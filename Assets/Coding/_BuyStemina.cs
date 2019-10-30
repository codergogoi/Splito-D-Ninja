using UnityEngine;
using System.Collections;
using Chartboost;

public class _BuyStemina : MonoBehaviour {
	
	private float tm;
	private int CountDown;
	private bool isLoaded;
	private bool isMenuLoading;
	
	public GameObject GameOverBg;
	public GameObject RetryBtn;
	public GameObject ExitBtn;
	public GameObject TextCounter;
	public bool isIgnore ;
	
	//Menu Loading
	public GameObject MenuLoadingText;
	public GameObject LoadingTexture;
	public GameObject loadingLight;
	private bool isFullGamePlay;
	
	
	private float loadingTimer;
	public Texture2D[] loadingImage;
	public Material LoaderMat;
	private int LoadingProgress = 10;
	
	private float loadingStime;
	private bool isTimer;
	private bool isSkipTimer;
	

	// Use this for initialization
	void Start () {
		CBBinding.cacheInterstitial("Default");
		CountDown = PlayerPrefs.GetInt("CDTime");
		//print(CountDown);
		//PlayerPrefs.SetInt("FULLGAME",0);
		
		if(PlayerPrefs.GetInt("FULLGAME") > 1){
			
			isFullGamePlay	 = true;
		}else{
			
			isFullGamePlay = false;
		}
		
		
		if(PlayerPrefs.GetInt("MENUINDEX") > 1){
			
			isMenuLoading = true;
		}else{
			isMenuLoading = false;
		}
		
		
		if(isMenuLoading){
			
			MenuLoadingText.SetActive(true);
			LoadingTexture.SetActive(true);
			TextCounter.SetActive(false);
			RetryBtn.SetActive(false);
			ExitBtn.SetActive(false);
			
			
			
			
			if(CountDown > 0 ){
				isSkipTimer = true;
				TextCounter.SetActive(true);
				RetryBtn.SetActive(true);
				loadingLight.SetActive(true);
			}else{
				isSkipTimer = false;
				loadingLight.SetActive(false);
				TextCounter.SetActive(false);
				RetryBtn.SetActive(false);
			}
			if(isFullGamePlay){
				
				TextCounter.SetActive(false);
			}
			
			
		}else{
			
			if(isFullGamePlay){
				LoadingTexture.SetActive(true);
				MenuLoadingText.SetActive(true);
				TextCounter.SetActive(false);
				RetryBtn.SetActive(false);
				ExitBtn.SetActive(false);
				
			}else{
				
				TextCounter.SetActive(true);
				LoadingTexture.SetActive(false);
				ExitBtn.SetActive(true);
				RetryBtn.SetActive(true);
			}
		}
		
		LoaderMat.mainTexture = loadingImage[10];
		
		 CBBinding.showInterstitial("Default");
		
	}
	
	#if UNITY_ANDROID || UNITY_IPHONE
	
	void OnEnable() {
		// Initialize the Chartboost plugin
		#if UNITY_ANDROID
				// Replace these with your own Android app ID and signature from the Chartboost web portal
				CBBinding.init("4f7b433509b6025804000002", "dd2d41b69ac01b80f443f5b6cf06096d457f82bd");
		#elif UNITY_IPHONE
				// Replace these with your own iOS app ID and signature from the Chartboost web portal
				CBBinding.init("538c8b2bc26ee441d13e3b1c", "c61e0dadbb900ee9a4baaedb5f21554fe9449ed4");
		#endif
	}
	
	void OnDisable() {
				// Shut down the Chartboost plugin
		#if UNITY_ANDROID
				CBBinding.destroy();
		#endif
	}
	
	
	#endif

	// Update is called once per frame
	void Update () {
		
			if(isFullGamePlay){
				
				LoadingTextureProgress(8.5f);
				return;
			
				
			}else if (isMenuLoading && !isSkipTimer ){
		
				
					LoadingTextureProgress(8.5f);
					
			}else{
				
				
		
						tm+= Time.deltaTime * 3;
						
						if(tm > 3.0f && !isLoaded){
							if(CountDown > 0)
								CountDown-= 1;
								PlayerPrefs.SetInt("CDTime",CountDown);
								tm= 0;
								LoadingStamina();
						}
						
					
						if(CountDown < 1 && !isLoaded){
							isLoaded = true;
							onExit();
							
						}
						
						TextCounter.gameObject.GetComponent<TextMesh>().text = "You have no enough stamina to run! Take some rest "+CountDown 
							+" \n or Purchase full Game to Quick Play by paing $0.99";
				
				}
			
			
			
		
	
	}
	
	
	 void LoadingTextureProgress(float tm){
		
	
		loadingTimer+= Time.deltaTime * tm;
		
		if(loadingTimer > 3 && LoadingProgress > 0){
			
			loadingTimer=0;
			LoadingProgress-=1;
			
			switch(LoadingProgress){
			
			
				case 0:
					LoaderMat.mainTexture = loadingImage[LoadingProgress];
					break;
				case 1:
					LoaderMat.mainTexture = loadingImage[LoadingProgress];
					break;
				case 2:
					LoaderMat.mainTexture = loadingImage[LoadingProgress];
					break;
				case 3:
					LoaderMat.mainTexture = loadingImage[LoadingProgress];
					break;
				case 4:
					LoaderMat.mainTexture = loadingImage[LoadingProgress];
					break;
				case 5:
					LoaderMat.mainTexture = loadingImage[LoadingProgress];
					break;
				case 6:
					LoaderMat.mainTexture = loadingImage[LoadingProgress];
					break;
				case 7:
					LoaderMat.mainTexture = loadingImage[LoadingProgress];
					break;
				case 8:
					LoaderMat.mainTexture = loadingImage[LoadingProgress];
					break;
				case 9:
					LoaderMat.mainTexture = loadingImage[LoadingProgress];
					break;
				case 10:
					LoaderMat.mainTexture = loadingImage[LoadingProgress];
					break;
		
			
		}
			
		}
		
		
		
		if(LoadingProgress < 1){
			
			StartCoroutine(WaitForGamePlay(0.5f));
		}
		
		
	}
	
	
	void LoadingStamina(){
		
		loadingStime+= Time.deltaTime;
		
		if(loadingStime > 3.0f){
			if(isTimer)
				isTimer = false;
			else
				isTimer = true;
			
			loadingStime = 0;
			
		}
		
		if(loadingLight.transform.position.x < 4.0f){
			
			loadingLight.transform.Translate(Vector3.right * Time.deltaTime/5);
		}else if(loadingLight.transform.position.x > -4.0f){
			
			loadingLight.transform.Translate(Vector3.left * Time.deltaTime/5);
		}
		
	}
	
	
	IEnumerator WaitForGamePlay(float tm){
		
		yield return new WaitForSeconds(tm);
			Application.LoadLevel("_GamePlay");
		
	}
	
	
	
	
	public void onInit(){
		
		StartCoroutine(WaitForBgAnim(0.2f));
		StartCoroutine(WaitForRetryAnim(0.3f));
		StartCoroutine(WaitForExitAnim(0.5f));
		
	}
	
	public void onExit(){
		
		StartCoroutine(WaitForBgAnimE(0.2f));
		StartCoroutine(WaitForRetryAnimE(0.3f));
		StartCoroutine(WaitForExitAnimE(0.5f));
		
	}
	//
	
	
	
	
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
		yield return new WaitForSeconds(1.0f);
		
		if(!isIgnore){
			int MyStemina = PlayerPrefs.GetInt("STEMINA");
			MyStemina+=10;
			 PlayerPrefs.SetInt("STEMINA",MyStemina);
			Application.LoadLevel("_GamePlay");
		}else{
			
			Application.LoadLevel("_MainMenu");
		}
		
		
		
	}
	
}
