using UnityEngine;
using System.Collections;

public class _CamActionInGame : MonoBehaviour {
	
	private Ray ray;
	private RaycastHit hit;
	public _GameOver gover;
	public LayerMask mask;
	private int Tryout;
	
	
	// Use this for initialization
	void Start () {
		
		Tryout = PlayerPrefs.GetInt("tryout");
		//PlayerPrefs.SetInt("CDTime",CountDown);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetMouseButtonDown(0)){
		
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
				if(Physics.Raycast(ray, out hit,500,mask)){
					
					
					//print(hit.collider.gameObject);
					
					if(hit.collider.tag=="retry"){
						 
						/*
						Tryout+=1;
					
						if(Tryout > 9){
							
							PlayerPrefs.SetInt("CDTime",25);
						
						}else if(Tryout > 6){
							
							PlayerPrefs.SetInt("CDTime",20);
						
						}else if(Tryout > 3){
							
							PlayerPrefs.SetInt("CDTime",15);
						}else{
							PlayerPrefs.SetInt("CDTime",10);
						}*/
					
					
					
						gover.onExit();
						StartCoroutine(WaitForRestart(1.3f));
					
					}
				
				
					if(hit.collider.tag=="exit"){
						
						gover.onExit();
						StartCoroutine(WaitForExit(1.3f));
					}
							
			}
			
		}
				
	
	}
	
	
	
	IEnumerator WaitForRestart(float tm){
		
		yield return new WaitForSeconds(tm);
		
		if(PlayerPrefs.GetInt("FULLGAME") > 1){
			
			
			Application.LoadLevel("_GamePlay");
			
		}else{
			
			if(PlayerPrefs.GetInt("STEMINA") < 1){
				
				PlayerPrefs.SetInt("MENUINDEX",0);
				int CountTime = PlayerPrefs.GetInt("TRYCDTime");
				PlayerPrefs.SetInt("CDTime",CountTime);
				Application.LoadLevel("_PreGame");
			
			}else{
				
				Application.LoadLevel("_GamePlay");
			}
			
			
			
			
		}
		
	}
	
	
	IEnumerator WaitForExit(float tm){
		
		yield return new WaitForSeconds(tm);
		
		if(PlayerPrefs.GetInt("FULLGAME") > 1){
			
			
			Application.LoadLevel("_MainMenu");
			
		}else{
			
			if(PlayerPrefs.GetInt("STEMINA") < 1){
				
				PlayerPrefs.SetInt("MENUINDEX",0);
				PlayerPrefs.SetInt("CDTime",15);
				Application.LoadLevel("_MainMenu");
			
			}else{
				
				Application.LoadLevel("_MainMenu");
			}
			
			
			
			
		}
		
	}
	
}
