using UnityEngine;
using System.Collections;

public class _triggerEnabler : MonoBehaviour {
	
	
	Vector2 deltaPosition;
    Vector2 afterDeltaPosition;
    float angle;
	
	private RaycastHit hit;
	public LayerMask mask;
	private bool isFall;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void StepDown(){
		
		isFall = true;
		StartCoroutine(WaitForFallDown(0.3f));
	}
	
	IEnumerator WaitForFallDown(float ftime){
		
		
		yield return new WaitForSeconds(ftime);
		
		isFall = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
//		print(isFall);
		
		Vector3 down = transform.TransformDirection (Vector3.down);
		
		Vector3 downx = transform.TransformDirection (Vector3.down);
		
		Vector3 up = transform.TransformDirection (Vector3.up);
		
		if (Physics.Raycast (transform.TransformPoint(0,0,0),up,out hit,100F,mask)) {
		
		
		 	if(hit.collider.tag=="toppath" || hit.collider.tag=="axe"){
			
				
					hit.collider.isTrigger = true;
				
			}
			
			
		
		}
		
		
		if (Physics.Raycast (transform.TransformPoint(0,0,0),down,out hit,100F,mask) && !isFall) {
			
			
			//print("first case");
			
			 if( hit.collider.tag=="toppath" || hit.collider.tag=="axe"){
			
				
				hit.collider.isTrigger = false;
				
			}
				
		}
		
		
		if (Physics.Raycast (transform.TransformPoint(0,0,0),downx,out hit,100F,mask) && isFall) {
			
			//print("2nd case");
			 if(hit.collider.tag=="toppath" || hit.collider.tag=="axe"){
				
				hit.collider.isTrigger = true;
				
				
			}
				
		}
	
	}
	

	
	
	
	
	
}
