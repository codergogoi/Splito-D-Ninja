using UnityEngine;
using System.Collections;

public class Blls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		
		
	}
	
	
	void OnCollisionEnter(Collision coll){
		
		
		if(coll.collider.tag=="coll"){
			
			
			rigidbody.velocity = transform.TransformDirection(0,0,14);
			
		}
		
		
	}
	
}
