using UnityEngine;
using System.Collections;

public class WheelCanon : MonoBehaviour {
	
	private float rotX;
	private float speed;
	private bool isOpposit;
	

	// Use this for initialization
	void Start () {
		
		speed = 500;

	}
	
	// Update is called once per frame
	void Update () {


			rotX+= Time.deltaTime * speed;

		
		transform.rotation = Quaternion.Euler(0,0,rotX);
		
	}
	
	void TriggerEnter(Collider coll){
		print(coll.collider.tag);
		
		if(coll.collider.tag=="Player"){
			
			
			
			speed = 2000000;
			
		}
		
	}
}
