using UnityEngine;
using System.Collections;

public class _CamActionBuy : MonoBehaviour {
	
	private Ray ray;
	private RaycastHit hit;
	public _BuyStemina bs;
	public LayerMask mask;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetMouseButtonDown(0)){
		
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
				if(Physics.Raycast(ray, out hit,500,mask)){
					
					
					//print(hit.collider.gameObject);
					
					if(hit.collider.tag=="quickplay"){
					
						StartCoroutine(WaitForBuy(1.3f));
					
					}
				
				
					if(hit.collider.tag=="exit"){
						bs.isIgnore = true;
						bs.onExit();
						//Application.LoadLevel("MainMenu");
					}
							
			}
			
		}
				
	
	}
	
	
	
	IEnumerator WaitForBuy(float tm){
		
		yield return new WaitForSeconds(tm);
		
			PlayerPrefs.SetInt("FULLGAME",2);
			PlayerPrefs.SetInt("STEMINA",100);
		
			bs.isIgnore = false;
			bs.onExit();
		// buy plugins request
		
	}
	
	
	
	
}
