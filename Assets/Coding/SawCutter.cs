using UnityEngine;
using System.Collections;

public class SawCutter : MonoBehaviour {
	
	private float rotX;
	private float speed;
	
	
	// Use this for initialization
	void Start () {
		
		speed = Random.Range(500,900);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		
	
			rotX-= Time.deltaTime * speed;
		
		
		
		
		transform.rotation = Quaternion.Euler(rotX,90,-90);
		
	}
}
