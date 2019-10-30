using UnityEngine;
using System.Collections;

public class _MainMenu : MonoBehaviour {
	
	private Ray ray;
	private RaycastHit hit;
	public LayerMask mask;
	
	
	// Use this for initialization
	void Start () {
		
		if(PlayerPrefs.GetInt("USEFLAG") < 1){
				PlayerPrefs.SetInt("STEMINA",100);
				PlayerPrefs.SetInt("USEFLAG",2); 
				PlayerPrefs.SetInt("TRYCDTime",5);
		}
		
		if(PlayerPrefs.GetInt("FULLGAME") > 1){
			PlayerPrefs.SetInt("STEMINA",100);
		}

		PlayerPrefs.SetInt("MENUINDEX",2);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetMouseButtonDown(0)){
		
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
				if(Physics.Raycast(ray, out hit,500,mask)){
					
					
					//print(hit.collider.gameObject);
					
					if(hit.collider.tag=="play"){
						
						StartCoroutine(WaitForRestart(0.5f));
					
					}
				
				
					if(hit.collider.tag=="options"){
						
						Application.LoadLevel("_Options");
					}
				
					if(hit.collider.tag=="gamecenter"){
						
						//load gamecenter
					}
						
							
			}
			
		}
				
	
	}
	
	
	
	IEnumerator WaitForRestart(float tm){
		
		yield return new WaitForSeconds(tm);
		
		Application.LoadLevel("_PreGame");
		
	}
}
