using UnityEngine;
using System.Collections;

public class WheelAIShooter : MonoBehaviour {
	
	private float rotX;
	private float speed;
	private bool isOpposit;
	
	
	// Use this for initialization
	void Start () {
		
		speed = Random.Range(50,200);
		
		if(transform.gameObject.name=="gaxe"){
			
			speed = 500;
		}
		
		
		if(speed > 160){
			isOpposit = true;
		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if(isOpposit){
			rotX-= Time.deltaTime * speed;
		}else{
			rotX+= Time.deltaTime * speed;
		}
		
		transform.rotation = Quaternion.Euler(0,0,rotX);
		
	}
	
	void TriggerEnter(Collider coll){
		print(coll.collider.tag);
		
		if(coll.collider.tag=="Player"){
			
			
			
			speed = 2000000;
			
		}
		
	}
}
