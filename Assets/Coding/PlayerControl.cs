using UnityEngine;
using System.Collections;

public class PlayerControl : _BaseClass {
	
	private int Stemina;
	// swipe parameter
	Vector2 deltaPosition;
    Vector2 afterDeltaPosition;
    float angle;
	
	private RaycastHit hit;
	private Ray ray;
	public LayerMask mask;
	public LayerMask attackMask;
	public LayerMask lm;
	
	// road arameter
	private GameObject Road;
	public GameObject RoadPoint;
	
	public GameObject[] Roads;
	
	
	public GUITexture reload;
	
	public AudioClip coinSound;
	public AudioClip jumpsound;
	
	private bool isJump;
	
	public GameObject particle;
	
	private int roadrand;
	private bool isRand, isRandEnd;
	
	
	public GameObject spoint;
	public Vector3 pos;
	private float tempy = 0;
	
	public GameObject bloodparticle;
	
	public GameObject bodyparts;
	
	private bool isOver;
	
	public GameObject LiveScore;
	public GameObject HighScore;
	public GameObject NowScore;
	public GameObject CollectedCoins;
	
	
	//score
	private float gametime;
	private int CurrentScore;
	private int BestScore;
	public int GoldCoins;
	
	
	//game manager
	public _GameManager gm;
	public _triggerEnabler trigger;
	
	public GameObject surican;
	public Transform suricanPoint;
	
	
	
	private bool isShield;
	private float balloneTime;
	private float sawTime;
	public GameObject Ballone;
	public GameObject SawPrefab;
	public GameObject CanonPrefab;
	public GameObject ProjectilePoint;
	
	public GameObject BlastParticle;
	private bool isBlast;
	
	private Vector3 BallonePos;
	private Vector3 sawPos;
	
	private int RandomEnemy;
	
	public Texture2D[] StaminaImage;
	public Material StaminaMat;
	public GameObject StaminaText;

	//enemy prefab
	private GameObject EnemyPrefab;
	
	// Use this for initialization
	void Start () {
		isJump = false;
		
		animation["run"].speed = 2.0f;
		BestScore = PlayerPrefs.GetInt("HighScore");
		CurrentFunds = PlayerPrefs.GetInt("TotalCoins");
		
		Stemina = PlayerPrefs.GetInt("STEMINA");
	
	}
	
	void Update(){
		
		balloneTime+= Time.deltaTime;
		
		if(balloneTime > Random.Range(2.5f,3.8f)){
			BallonePos = new Vector3(ProjectilePoint.transform.position.x,Random.Range(18.0f,24.0f),0);
			GameObject go = Instantiate(Ballone,BallonePos,Quaternion.identity) as GameObject;
			balloneTime = 0;
		}
		
		sawTime+= Time.deltaTime;
		if(sawTime > Random.Range(3.5f,4.8f)){
			RandomEnemy = Random.Range(0,5);
			if(RandomEnemy > 3){

				EnemyPrefab = SawPrefab;
			}else{
				EnemyPrefab = CanonPrefab;
			}
			sawPos = new Vector3(ProjectilePoint.transform.position.x,1.77f,0);
			GameObject go = Instantiate(EnemyPrefab,sawPos,Quaternion.identity) as GameObject;
			sawTime = 0;
		}
		
		gametime += Time.deltaTime * 10;
							
		CurrentGameScore = ((int) Mathf.Round(gametime));
		
		
		LiveScore.GetComponent<TextMesh>().text = ""+CurrentGameScore;
		NowScore.GetComponent<TextMesh>().text = "Score : "+CurrentGameScore;
		CollectedCoins.GetComponent<TextMesh>().text = "Coins :"+ CurrentFunds+"/"+GoldCoins;
		HighScore.GetComponent<TextMesh>().text = "Best Score : "+BestScore;
		StaminaText.GetComponent<TextMesh>().text = ""+Stemina+"%";
		
				if(Stemina > 99){
					
					StaminaMat.mainTexture = StaminaImage[0];
				}else if(Stemina >90){
					
					StaminaMat.mainTexture = StaminaImage[1];
				}else if(Stemina > 80){
					
					StaminaMat.mainTexture = StaminaImage[2];
				}else if(Stemina > 70){
					
					StaminaMat.mainTexture = StaminaImage[3];
				}else if(Stemina > 60){
					
					StaminaMat.mainTexture = StaminaImage[4];
				}else if(Stemina > 50){
					
					StaminaMat.mainTexture = StaminaImage[5];
				}else if(Stemina > 40){
					
					StaminaMat.mainTexture = StaminaImage[6];
				}else if(Stemina > 30){
					
					StaminaMat.mainTexture = StaminaImage[7];
				}else if(Stemina > 20){
					
					StaminaMat.mainTexture = StaminaImage[8];
				}else if(Stemina > 10){
					
					StaminaMat.mainTexture = StaminaImage[9];
				}else if(Stemina > 0){
					
					StaminaMat.mainTexture = StaminaImage[10];
				}
		
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
		if(Input.GetKeyDown("mouse 0")){
			
			if(Physics.Raycast(ray, out hit,500,lm)){
				
				//if(hit.collider.tag=="ship"){
				suricanPoint.LookAt(hit.point);
				GameObject go = Instantiate(surican, suricanPoint.position, Quaternion.identity) as GameObject;
				go.rigidbody.AddForce(suricanPoint.forward * 5000);
				//}
				
			}
		}
		
		/*
		Vector3 fwd = transform.TransformDirection (Vector3.up);
		
		if (Physics.Raycast (transform.TransformPoint(Vector3.zero),fwd,out hit,500f)) {
		
		
		 	if(hit.collider.tag=="axe"){
				//CurrentScore+= 1;
				//print("One wheel crossed");
				
			}
			
			Debug.DrawLine(transform.position,hit.point,Color.red);
		
		} */
		
		
		transform.position = new Vector3(transform.position.x, transform.position.y,0);
		transform.rotation = Quaternion.Euler(0,90,0);
			
			if(Input.GetKeyDown(KeyCode.A)){
				animation.CrossFade("attack", 0.2F);
				StartCoroutine(waitforstart(0.2f));
			}
			
		
			if(Input.GetKeyDown(KeyCode.H)){
			
					isShield = true;
					print(isShield);
				}
			
			if(Application.platform == RuntimePlatform.IPhonePlayer){
			
				
				
					if(Input.touchCount > 0 &&  Input.touches[0].phase == TouchPhase.Moved)
			            { 
				
				
				
					                //its always x=-1 and y=-1 if touchCount == 0 Resets
					                if(deltaPosition.x == -1 && deltaPosition.y == -1)
					                    deltaPosition = Input.GetTouch(0).position; //First touch  point stored
					                afterDeltaPosition = Input.GetTouch(0).position;//the swiping points
					                angle = Mathf.Atan2(afterDeltaPosition.y-deltaPosition.y,afterDeltaPosition.x -deltaPosition.x)* 180/Mathf.PI ; // angle in degrees from 0,-180 and 0,180)
					                //Debug.Log("Angle "+ angle);
					                
									if(angle < 45f && angle > -45f)
					                {
									
					              		//SendMessage("JumpAction", 2);
								 		//right
									
							        }
							        else if(angle < 135f && angle > 45f)
							        {
							           		
											PlayerJumpAction();
											
											//Log.text ="up";
							               
							        }
							        else if(angle > 135f || angle < -135f)
							        {
											// left
											//SendMessage("JumpAction", 2);
											
											
							        }
							        else if(angle > -135f && angle < -45f)
							        {
										//trigger.StepDown();
							            //down
										
							        }
					
							
						
					    }else if(Input.touchCount > 0 &&  Input.touches[0].phase == TouchPhase.Began){
			
									ray = Camera.main.ScreenPointToRay(Input.mousePosition);
								
									if(Physics.Raycast(ray, out hit,500,mask)){
												
												
										if(hit.collider.tag=="jump"){
												
												PlayerJumpAction();
											
											}
									
										if(hit.collider.tag=="down"){
											
											
												trigger.StepDown();
										
										}
								
									//print(hit.collider.tag);
							}
						
						}
					    else if( Input.touchCount == 0)
					    {
					        if(deltaPosition.x != -1 && deltaPosition.y != -1)
					        {
					            deltaPosition.x=-1;
					            deltaPosition.y=-1;
					        }
						}
						
				 
				
			}else{
			
				if(Input.GetMouseButtonDown(0)){
					
						ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					
						if(Physics.Raycast(ray, out hit,500,mask)){
									
									
										
							if(hit.collider.tag=="jump"){
								
								PlayerJumpAction();
							
							}
					
							if(hit.collider.tag=="down"){
							
							
								trigger.StepDown();
						
						}
					
					
				
						//print(hit.collider.tag);
					}
				}
			
				if(Input.GetKeyDown(KeyCode.Space)){
			
					PlayerJumpAction();
				}
			
				
			
			
			}
			
			
		
		
		
			
			
		
		
	
	}
	
	void PlayerJumpAction(){
		
		if(!isJump){
			audio.pitch = 1;
			audio.PlayOneShot(jumpsound);
			isJump = true;
		}
		SendMessage("JumpAction", 2);
		animation.CrossFade("jump", 0.2F);
		StartCoroutine(waitforrun(0.5f));
	}
	
	
	
	IEnumerator waitforrun(float jtime){
		
		
		yield return new WaitForSeconds(jtime);
		
		  animation.CrossFade("jumpland", 0.2F);
		  isJump = false;
			StartCoroutine(waitforstart(0.1f));
		
	}
	
	
	
	IEnumerator waitforstart(float jtime){
		
		
		yield return new WaitForSeconds(jtime);
		   animation.CrossFade("run", 0.2F);
		
	}
	
	IEnumerator WaitForJumpStop(float tm){
		
		
		yield return new WaitForSeconds(tm);
		   SendMessage("JumpAction", 1);
		
	}
	
	
	
	void OnTriggerEnter(Collider coll){
		
		if(coll.collider.tag=="saw"){
			
			if(!isBlast){
				GameObject go1 = Instantiate(BlastParticle,transform.position,Quaternion.identity) as GameObject;
				
				Handheld.Vibrate();
				Destroy(gameObject,0.2f);
					isBlast = true;
			}
			
			
		}
		

		
		if(coll.collider.tag == "newroad"){
			
			RoadPoint = GameObject.Find("_instpoint");
		
			
				roadrand = Random.Range(0,7);
				
				switch (roadrand){
					
					case 0:
						Road = Roads[0];
						break;
					case 1:
						Road = Roads[1];
						break;
					case 2:
						Road = Roads[2];
						break;
					case 3:
						Road = Roads[3];
						break;
					case 4:
						Road = Roads[4];
						break;
					case 5:
						Road = Roads[5];
						break;
					case 6:
						Road = Roads[6];
						break;
					case 7:
						Road = Roads[7];
						break;
			
					
				}
			
			GameObject CloneRoad = Instantiate(Road, RoadPoint.transform.position,Quaternion.identity) as GameObject;
			Destroy(RoadPoint);
			Destroy(coll.gameObject);
			pos.x = spoint.transform.position.x + 25;
			
				
				
			}
			
		 
		
		
		if(coll.collider.tag=="GC"){
			
			//particle.SetActive(true);
			audio.PlayOneShot(coinSound);
			if(audio.pitch < 2.0f){
				
				audio.pitch+= 0.05f;
			}else{
				audio.pitch = 1;
			}
			GoldCoins+= 1;
			
			CurrentFunds= GoldCoins;
			//StartCoroutine(WaitForHide(0.5f));
			//print("coin collect");
			
		}
		
		
	
		
	}
	
	

	
	
 
	
	
	
	IEnumerator WaitForHide(float htime){
		
		yield return new WaitForSeconds(htime);
		//particle.SetActive(false);
		audio.pitch = 1;
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
        
		if(hit.collider.tag=="GC"){
			GoldCoins+= 2;
			//print("coin collect");
			Destroy(hit.collider.gameObject);
		}
		
		if(hit.collider.tag=="fireball"){
			
			if(!isBlast){
				GameObject go1 = Instantiate(BlastParticle,transform.position,Quaternion.identity) as GameObject;
				
				Handheld.Vibrate();
				Destroy(gameObject,0.2f);
					isBlast = true;
			}
			/*GameObject go  = GameObject.Find("blood(Clone)");
			/*if(!go){
				Instantiate(bloodparticle);
				Stemina-= 10;
			}
			*/
			//Destroy(hit.collider.gameObject,0.5f);
			
		}
		
		if(hit.collider.tag=="saw"){
			
		
		
			if(!isOver && !isShield){
				
				GameObject parts = Instantiate(bodyparts,transform.position,transform.rotation) as GameObject;
				parts.rigidbody.velocity = new Vector3(10,10,20);
				Handheld.Vibrate();
				Destroy(gameObject);
				isOver = true;
			}
			
			
			//print(hit.collider.gameObject);
			
		}
		
		/*
		if(hit.collider.tag=="stemina"){
			
			Stemina-= 1;
			//print("You have Stemina.."+ Stemina);
			
		}*/
		
		
		
			
		
		
		
    }
	
	public void DestroyMe(){
		
			if(!isOver){
				
				GameObject parts = Instantiate(bodyparts,transform.position,transform.rotation) as GameObject;
				parts.rigidbody.velocity = new Vector3(10,10,20);
				Handheld.Vibrate();
				Destroy(gameObject);
				isOver = true;
			}
			
		
	}
	
	
	void OnDestroy(){
		
		if(Stemina > 0 && PlayerPrefs.GetInt("FULLGAME") < 1){
			Stemina-= 10;
			PlayerPrefs.SetInt("STEMINA",Stemina);
		}
		
		gm.OnGameOver(true);
		
		if(CurrentGameScore > BestScore){
			BestScore = CurrentGameScore;
			PlayerPrefs.SetInt("HighScore",BestScore);
		}
		
		PlayerPrefs.SetInt("TotalCoins",CurrentFunds);
		
	}
	
	
	
	
	
}
