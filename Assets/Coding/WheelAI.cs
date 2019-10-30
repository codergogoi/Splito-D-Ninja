using UnityEngine;
using System.Collections;

public class WheelAI : MonoBehaviour {
	
	private float rotX;
	private float speed;
	private bool isOpposit;
	
	
	// Use this for initialization
	void Start () {
		
		speed = Random.Range(50,600);
		
		if(transform.gameObject.name=="gaxe"){
			
			speed = 300;
		}
		
		
		if(speed >= Random.Range(100,550)){
			isOpposit = true;
		
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(isOpposit){
			rotX-= Time.deltaTime * speed;
		}else{
			rotX-= Time.deltaTime * speed;
		}
		
		
		
		transform.rotation = Quaternion.Euler(rotX,-90,0);
		
	}
}
